using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Faculty : Document
    {
        public string Initial { get; set; }
        public string Designation { get; set; }
        public List<Section> Sections { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
    }
}