using MySql.Data.MySqlClient; //https://dev.mysql.com/downloads/connector/net/6.10.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class DBC
    {
        private string connectionString = "server=127.0.0.1;uid=root;pwd=;database=notspotify_db";
        private MySqlConnection conn = new MySqlConnection();
        private Hasher hasher = new Hasher();


        public DBC()
        {
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
            conn.ConnectionString = connectionString;
            conn.Open();
            string query = "SELECT COUNT(*) FROM users WHERE `username` = @username";
            MySqlCommand statement = new MySqlCommand(query, conn);
            statement.Parameters.AddWithValue("@username", username);
            if (Convert.ToInt32(statement.ExecuteScalar()) > 0)
            {
                return true;
            }
            else
            {
                return false;
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
    }
}
