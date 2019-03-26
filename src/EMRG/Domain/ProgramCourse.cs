using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProgramCourse : Document
    {
        public int ProgramId { get; set; }
        public Domain.Program program { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }

        public string type { get; set; }
    }
}
