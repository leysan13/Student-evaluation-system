using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
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
        private string group; //группа

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

      
        private int mark_pr; //оценка по программированию

        public int Mark_pr
        {
            get { return mark_pr; }
            set { mark_pr = value; }
        }
       
        private int mark_discr; //оценка по дискретной математике

        public int Mark_discr
        {
            get { return mark_discr; }
            set { mark_discr = value; }
        }
        private int mark_terver; //оценка по теории вероятностей

        public int Mark_terver 
        {
            get { return mark_terver; }
            set { mark_terver = value; }
        }
        private int mark_philosophy; //оценка по философии

        public int Mark_philosophy
        {
            get { return mark_philosophy; }
            set { mark_philosophy = value; }
        }

        private int mark_law; //оценка по праву

        public int Mark_law
        {
            get { return mark_law; }
            set { mark_law = value; }
        }
        private int mark_economics; //оценка по экономике

        public int Mark_economics
        {
            get { return mark_economics; }
            set { mark_economics = value; }
        }
        public Student(string _sername, string _name, string _group, int _mark_pr, int _mark_discr, int _mark_terver, int mark_phil, int _mark_law, int mark_ec)
        {
            sername = _sername;
            name = _name;
            group = _group;
            mark_pr = _mark_pr;
            mark_discr =_mark_discr;
            mark_terver = _mark_terver;
            mark_philosophy = mark_phil;
            mark_law = _mark_law;
            mark_economics = mark_ec;
        }

    }
}
