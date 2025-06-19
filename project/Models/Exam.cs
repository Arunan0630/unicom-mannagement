using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Models
{
    internal class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int SubjectID { get; set; }
        public string ExamDate{ get; set; }

    }
}
