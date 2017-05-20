using System;

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

        public Marks marks;

        public Students(string _sername, string _name, string _patronymic, string _group, string subject, int _mark)
        {
            sername = _sername;
            name = _name;
            patronymic = _patronymic;
            group = _group;
            marks = new Marks(subject, _mark);
        }
        public int GetMark(string _subject)
        {
            int mark;
            switch (_subject)
            {
                case "Программирование":
                    mark = marks.Programming;
                    break;
                case "Экономика":
                    mark = marks.Economics;
                    break;
                case "Математический анализ":
                    mark = marks.Mathematical_analysis;
                    break;
                default:
                    mark = 0;
                    break;
            }
            return mark;
        }
    }
}