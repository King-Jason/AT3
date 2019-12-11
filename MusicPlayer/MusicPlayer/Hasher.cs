using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Hasher
    {
        //Jason King
        //P465642
        //12/12/2019
        private RNGCryptoServiceProvider cSP = new RNGCryptoServiceProvider();
        private int SALT_SIZE = 40;
        UTF8Encoding enc8 = new UTF8Encoding();

        public Hasher() { }

        /*
         * Generates a hashed password including salt
         */ 
        public string getHashedPassword(string password)
        {
            string salt = generateSalt();
            string saltedPassword = password + salt;
            string hashedPassword = hashPassword(saltedPassword);
            return hashedPassword + "|" + salt;
        }

        public string generateSalt()
        {
            byte[] randomBytes = new byte[SALT_SIZE];
            cSP.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public string hashPassword(string saltedPassword)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = enc8.GetBytes(saltedPassword);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return Convert.ToBase64String(resultBytes);
        }

        public bool isPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == hashPassword(finalString);
        }
    }
}
