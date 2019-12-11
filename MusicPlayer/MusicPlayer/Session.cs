using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Session
    {
        //Jason King
        //P465642
        //12/12/2019
        public int userID { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool loggedIn { get; set; }

        public Session() { }

        public Session(string Email, string Username, string Password, int UserID)
        {
            email = Email;
            username = Username;
            password = Password;
            userID = UserID;
        }
        public void newSession(string Email, string Username, string Password, int UserID)
        {
            email = Email;
            username = Username;
            password = Password;
            userID = UserID;
        }
    }
}
