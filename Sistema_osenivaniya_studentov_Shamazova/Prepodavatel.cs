using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    class Prepodavatel
    {
        private string fam;

        public string Fam
        {
            get { return fam; }
            set { fam = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string otch;

        public string Otch
        {
            get { return otch; }
            set { otch = value; }
        }
        private string predmet;

        public string Predmet
        {
            get { return predmet; }
            set { predmet = value; }
        }
        private string log;

        public string Log
        {
            get { return log; }
            set { log = value; }
        }
        private string parol;

        public string Parol
        {
            get { return parol; }
            set { parol = value; }
        }

        public Prepodavatel()
        {

        }

    }
}
