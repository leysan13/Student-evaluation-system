using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    class Student
    {
        private string fam; //фамилия студента

        public string Fam
        {
            get { return fam; }
            set { fam = value; }
        }
        private string name; //имя студента

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string otch;//отчество студента

        public string Otch
        {
            get { return otch; }
            set { otch = value; }
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
        /*   
          private int mark_economics; //оценка по экономике

          public int Mark_economics
          {
              get { return mark_economics; }
              set { mark_economics = value; }
          }
        private int mark_matan; //оценка по Математическому анализу

          public int Mark_matan
          {
              get { return mark_matan; }
              set { mark_matan = value; }
          }*/
        public Student(string _fam, string _name, string _otch, string _group, int _mark_pr)
        {
            fam = _fam;
            name = _name;
            otch = _otch;
            group = _group;
            mark_pr = _mark_pr;
       //     mark_matan = _mark_matan;
          //  mark_economics = mark_ec;
        }

       public string[] Show(Student st, string predmet)
        {
           
            string[] mstr = new string[5];
            mstr[0] = Fam;
            mstr[1] = Name;
            mstr[2] = Otch;
            mstr[3] = Group;
            mstr[4] = Mark_pr.ToString();
            return mstr;
        }
    }
}
