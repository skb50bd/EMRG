using System.Collections.Generic;

namespace Domain
{
    public class Section : Document
    {
        public int Number { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<Student> Students { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }


    }

}
