using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{   
    [Serializable]
    public class Prepodavatel
    {
        private string sername;

        public string Sername
        {
            get { return sername; }
            set { sername = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string patronymic;

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        private string predmet;

        public string Predmet
        {
            get { return predmet; }
            set { predmet = value; }
        }
     /*   private string login;

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
        */
        public Prepodavatel(string _sername, string _name, string _patronymic, string _predmet/*, string _login, string _parol */)
        {
            sername = _sername;
            name = _name;
            patronymic = _patronymic;
            predmet = _predmet;

        }

    }
}
