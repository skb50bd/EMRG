using System.Collections.Generic;


namespace Domain
{
    public class Department : Document
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Program> Programs { get; set; }
        public List<Course> Courses { get; set; }
        public List<Faculty> Faculties { get; set; }
        public List<Student> Students { get; set; }
    }
}
