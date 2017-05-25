using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{   
    [Serializable]
    public class Teacher
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
        private string subject;

        public string Subject
        {
            get { return subject;
            }
            set { subject = value; }
        }
        private List<HistoryOfChanges> history;

        public List<HistoryOfChanges> History
        {
            get { return history; }
            set { history = value; }
        }


        public Teacher(string _sername, string _name, string _patronymic, string _subject)
        {
            sername = _sername;
            name = _name;
            patronymic = _patronymic;
            subject = _subject;

        }
        public void MakeIt10()
        {
            int j = 0;
            while (history.Count>10)
            {
                for (int i = history.Count-10; i < history.Count; i++)
                {
                    history[j] = history[i];
                    j++;
                    
                }

                history.RemoveAt(history.Count-1);
            }
        }
    }
}
