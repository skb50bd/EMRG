using System.Collections.Generic;

namespace Domain
{
    public class Course : Document
    {
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string Code {get;set;}

        public string Name { get; set; }

        public int Credits { get; set; }

        public virtual List<Section> Sections { get; set; }
    }
}