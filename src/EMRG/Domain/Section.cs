using System.Collections.Generic;

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

        public virtual List<Student> Students { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public  Schedule Schedule { get; set; }
    }

}
