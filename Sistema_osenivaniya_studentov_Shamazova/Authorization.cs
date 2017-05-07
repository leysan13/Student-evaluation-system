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
        private Studentp st;

        public Studentp St
        {
            get { return st; }
            set { st = value; }
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
        public Authorization(string _login, string _parol, Studentp _st)
        {
            login = _login;
            parol = _parol;
            st = _st;
        }

    }
}
