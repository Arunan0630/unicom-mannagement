using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Models
{
    internal class Timetable
    {
        public int TimetableID { get; set; }
        public int SubjectID { get; set; }   
        public string TimeSlot { get; set; } 
        public int RoomID { get; set; }
    }
}
