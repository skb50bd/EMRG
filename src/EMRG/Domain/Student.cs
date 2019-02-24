using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain
{
    public class Student : Document
    {
        [Display(Name = "Student Id")]
        public string StudentId => 
            AdmissionDate.Year + "-" 
            + (AdmissionDate.Month - 1) / 4 + 1 + "-" 
            + Program.Code + "-" 
            + Roll;

        public int Roll { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Display(Name = "Program")]
        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }
        
        public DateTimeOffset AdmissionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateOfBirth { get; set; }


        [Display(Name = "Credits Taken")]
        public int CreditsTaken => 
            Sections?.Select(s => s.Course)
            .Distinct()
            .Sum(c=> c.Credits) ?? 0;

        [Display(Name = "Credits Earned")]
        public int CreditsEarned =>
            Enrollments?.Where(e => e.Grade > Grade.F)
                .Select(e => e.Section)
                .Select(s => s.Course)
                .Distinct()
                .Sum(c => c.Credits) ?? 0;

        public List<CourseEnrollment> Enrollments { get; set; }
        public List<Section> Sections => Enrollments?.Select(e => e.Section).ToList();
    }
}