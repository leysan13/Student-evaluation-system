﻿using System;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
   public class Student
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

        private int mark; //оценка 

        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public Student(string _subject, Students student)
        {
            sername = student.Sername;
            name = student.Name;
            patronymic = student.Patronymic;
            group = student.Group;
            switch (_subject)
            {
                case "Программирование":
                    mark = student.marks.Programming;
                    break;
                case "Экономика":
                    mark = student.marks.Economics;
                    break;
                case "Математический анализ":
                    mark = student.marks.Mathematical_analysis;
                    break;
                default:
                    mark = 0;
                    break;
            }
        }
    }
}
