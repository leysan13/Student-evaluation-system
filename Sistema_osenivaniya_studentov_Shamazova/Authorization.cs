using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
    class Authorization
    {
        private object user;

        public object User
        {
            get { return user; }
            set { user = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Authorization(string _login, string _password, object _user)
        {
            login = _login;
            password = _password;
            user = _user;
        }

    }
}
