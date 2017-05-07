using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
    class Student
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

      
        private int mark; //оценка по программированию

        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public Student(string _sername, string _name, string _patronymic, string _group, int _mark)
        {
            sername = _sername;
            name = _name;
            patronymic = _patronymic;
            group = _group;
            mark = _mark;

        }
       
    }
}
