using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
    class Students
    {
            private string sername; //фамилия студента

            public string Sername
            {
                get { return sername; }
                set { sername = value; }
            }
            private string name; //имя студента

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string patronymic;//отчество студента

            public string Patronymic
            {
                get { return patronymic; }
                set { patronymic = value; }
            }
            private string group; //группа


            public string Group
            {
                get { return group; }
                set { group = value; }
            }


            private int programing=0; //оценка по программированию

            public int Programing
            {
                get { return programing; }
                set { programing = value; }
            }

            private int econ=0;

            public int Econ
            {
                get { return econ; }
                set { econ = value; }
            }

            private int mathematical_analysis=0;

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

            public Students(string _sername, string _name, string _patronymic, string _group, string subject, int _mark)
            {
                sername = _sername;
                name = _name;
                patronymic = _patronymic;
                group = _group;
                switch (subject)
                {
                    case "Программирование":
                        programing = _mark;
                        break;
                    case "Экономика":
                        econ = _mark;
                        break;
                    case "Математический анализ":
                        mathematical_analysis = _mark;
                        break;
                    default:
                        break;
                }

            }

        }
    }
