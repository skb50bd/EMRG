using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Program : Document
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        [Display(Name = "Minimum Credits Required")]
        public string RequiredCredits { get; set; }
        public List<Course> CompulsoryCourses { get; set; }
        public List<Course> OptionalCourses { get; set; }
        public List<Student> Students { get; set; }
    }
}
