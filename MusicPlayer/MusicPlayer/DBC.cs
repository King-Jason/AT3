using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class DBC
    {
        //Jason King
        //P465642
        //12/12/2019
        private string connectionString = "";
        private MySqlConnection conn = new MySqlConnection();
        private Hasher hasher = new Hasher();
        private Connection connection = new Connection();


        public DBC()
        {
        }
        /*
        public void EncryptString()
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes("Jason"));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes("server=127.0.0.1;uid=root;pwd=;database=notspotify_db");
                    connection.connectionString = (Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length)));
                    FileStream fs = new FileStream("connection.dat", FileMode.Create);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, connection);
                    fs.Close();
                }
            }
        }
        */
        public void DecryptString()
        {
            try
            {
                FileStream fs = new FileStream("connection.dat", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                connection = (Connection)formatter.Deserialize(fs);
                fs.Close();

                using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
                {
                    using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                    {
                        byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes("Jason"));
                        tripleDESCryptoService.Key = byteHash;
                        tripleDESCryptoService.Mode = CipherMode.ECB;
                        byte[] data = Convert.FromBase64String(connection.connectionString);
                        connectionString = Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                    }
                }
            }
            catch (IOException io)
            {
            }

        }
        public void createUser(string email, string username, string password)
        {
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string[] hashedPassword = hasher.getHashedPassword(password).Split('|');
            string query = "INSERT INTO `users`(`email`, `username`, `password`, `salt`) VALUES (@email,@username,@password,@salt)";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@email", email);
            statement.Parameters.AddWithValue("@password", hashedPassword[0]);
            statement.Parameters.AddWithValue("@salt", hashedPassword[1]);
            statement.Parameters.AddWithValue("@username", username);
            statement.ExecuteReader();
            conn.Close();
        }

        public bool testConnection()
        {
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool checkIfUserExists(string username)
        {
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT COUNT(*) FROM users WHERE `username` = @username";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@username", username);
            if (Convert.ToInt32(statement.ExecuteScalar()) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool login(string username, string password)
        {
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT `username`, `password`, `salt` FROM `users` WHERE `username`= @username";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@username", username);
            MySqlDataReader login = statement.ExecuteReader();
            if (login.Read())
            {
                string idValue = login.GetString("username");
                string passwordValue = login.GetString("password");
                string saltValue = login.GetString("salt");

                if (hasher.isPasswordMatch(password, saltValue, passwordValue))
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            else
            {
                conn.Close();
                return false;
            }

        }

        public string getEmailFromAccount(string username)
        {
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT `email` FROM `users` WHERE `username`= @username";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@username", username);
            MySqlDataReader login = statement.ExecuteReader();
            string Email = "";
            if (login.Read())
            {
                Email = login.GetString("email");
            }
            return Email;
        }
        public int getUserID(string username)
        {
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT `id` FROM `users` WHERE `username`= @username";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@username", username);
            MySqlDataReader login = statement.ExecuteReader();
            if (login.Read())
            {
                int userID = login.GetInt32("id");
                return userID;
            }else
            {
                return 0;
            }
        }

        public void addSongToDB(int userID, string songName, string artistName, string songPath)
        {
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "INSERT INTO `usersongs`(`userID`, `songName`, `artistName`, `songPath`) VALUES (@userID,@songName,@artistName,@songPath)";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@userID", userID);
            statement.Parameters.AddWithValue("@songName", songName);
            statement.Parameters.AddWithValue("@artistName", artistName);
            statement.Parameters.AddWithValue("@songPath", songPath);
            statement.ExecuteReader();
            conn.Close();
        }

        public LinkedList<Song> getUsersSongs(int userID)
        {
            LinkedList<Song> songList = new LinkedList<Song>();
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT * FROM `usersongs` WHERE `userID` = @userID";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@userID", userID);
            MySqlDataReader songs = statement.ExecuteReader();
            while (songs.Read())
            {
                Song newSong = new Song();
                newSong.userID = songs.GetInt32("userID");
                newSong.songName = songs.GetString("songName");
                newSong.artistName = songs.GetString("artistName");
                newSong.songPath = songs.GetString("songPath");
                songList.AddLast(newSong);
            }
            conn.Close();
            return songList;
        }

        public void removeSong(int userID, string songPath)
        {
            conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "DELETE FROM `usersongs` WHERE `userID` = @userID AND `songPath` = @songPath";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@userID", userID);
            statement.Parameters.AddWithValue("@songPath", songPath);
            statement.ExecuteReader();
            conn.Close();
        }
    }
}
