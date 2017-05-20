using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
    public class Marks
    {
        public Marks(string subject, int _mark)
        {
            switch (subject)
            {
                case "Программирование":
                    programming = _mark;
                    break;
                case "Экономика":
                    economics = _mark;
                    break;
                case "Математический анализ":
                    mathematical_analysis = _mark;
                    break;
                default:
                    break;
            }
        }

        private int programming = 0; //оценка по программированию

        public int Programming
        {
            get { return programming; }
            set { programming = value; }
        }

        private int economics = 0;

        public int Economics
        {
            get { return economics; }
            set { economics = value; }
        }

        private int mathematical_analysis = 0;

        public int Mathematical_analysis
        {
            get
            {
                return mathematical_analysis;
            }
            set
            {
                mathematical_analysis = value;
            }
        }
    }
}
