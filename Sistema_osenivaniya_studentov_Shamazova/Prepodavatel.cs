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

        public Prepodavatel(string _fam, string _name, string _otch, string _predmet, string _log, string _parol )
        {
            fam = _fam;
            name = _name;
            otch = _otch;
            predmet = _predmet;
            log = _log;
            parol = _parol;
        }

    }
}
