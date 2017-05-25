using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    [Serializable]
   public class HistoryOfChanges
    {
        
        private Authorization studentBefore;

        public Authorization StudentBefore
        {
            get { return studentBefore; }
            set { studentBefore = value; }
        }
        private Authorization studentAfter;

        public Authorization StudentAfter 
        {
            get { return studentAfter; }
            set { studentAfter = value; }
        }
        public HistoryOfChanges(Authorization before, Authorization after)
        {
            studentBefore = before;
            studentAfter = after;
        }

    }
}
