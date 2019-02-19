using System.Collections.Generic;

namespace Domain
{
    public class Faculty : Document
    {
        public string Initials { get; set; }
        public string Designation { get; set; }
        public List<Section> Sections { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
    }
}