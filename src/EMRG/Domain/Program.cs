using System.Collections.Generic;


namespace Domain
{
    public class Program : Document
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string RequiredCredits { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
    }
}
