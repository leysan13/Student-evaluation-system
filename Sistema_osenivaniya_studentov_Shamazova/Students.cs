using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
         public class Students
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


            private int programming=0; //оценка по программированию

            public int Programming
            {
                get { return programming; }
                set { programming = value; }
            }

            private int economics=0;

            public int Economics
            {
                get { return economics; }
                set { economics = value; }
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
        public int GetMark(string _subject)
        {
            int mark;
            switch (_subject)
            {
                case "Программирование":
                    mark = Programming;
                    break;
                case "Экономика":
                    mark = Economics;
                    break;
                case "Математический анализ":
                    mark = Mathematical_analysis;
                    break;
                default:
                    mark = 0;
                    break;
                   
            }
            return mark;
        }
        }
    }
