using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Course : Document
    {
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Display(Name = "Course Code")]
        public string Code {get;set;}

        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Display(Name = "Credits")]
        public int Credits { get; set; }

        public virtual List<Section> Sections { get; set; }
    }
}