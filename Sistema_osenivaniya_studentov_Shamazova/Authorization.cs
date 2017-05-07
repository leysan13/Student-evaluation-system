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
        private string parol;

        public string Parol
        {
            get { return parol; }
            set { parol = value; }
        }
        public Authorization(string _login, string _parol, object _user)
        {
            login = _login;
            parol = _parol;
            user = _user;
        }

    }
}
