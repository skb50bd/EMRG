using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Section : Document
    {
        public int Number { get; set; }

        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        public virtual List<CourseEnrollment> Enrollments { get; set; }

        public virtual List<Student> Students => 
            Enrollments?.Select(e => e.Student).ToList();

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public  Schedule Schedule { get; set; }

        public int Seat { get; set; }
    }

}
