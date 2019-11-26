using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Session
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool loggedIn { get; set; }

        public Session() { }

        public Session(string Email, string Username, string Password)
        {
            email = Email;
            username = Username;
            password = Password;
        }
        public void newSession(string Email, string Username, string Password)
        {
            email = Email;
            username = Username;
            password = Password;
        }
    }
}
