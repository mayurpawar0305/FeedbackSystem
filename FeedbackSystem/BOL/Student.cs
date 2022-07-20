using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Student
    {
        public int FeedbackId { get; set; }
        public DateTime Date { get; set; }
        public string StudentName { get; set; }
        public string Module { get; set; }
        public string Faculty { get; set; }
        public int ProblemSolvingRating { get; set; }
        public int PresentationSkill { get; set; }
        public string Comments { get; set; }

    }
}
