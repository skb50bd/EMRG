using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain
{

    public class Student : Person
    {
        [Display(Name = "Student Id")]
        public string StudentId => this.GetStudentId();

        public int Roll { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Display(Name = "Program")]
        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }

        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int Age => DateOfBirth.CalculateAge();

        [Display(Name = "Credits Taken")]
        public int CreditsTaken => this.CalculateCreditsTaken();

        [Display(Name = "Credits Earned")]
        public int CreditsEarned => this.CalculateCreditsEarned();

        public List<CourseEnrollment> Enrollments { get; set; }
        public List<Section> Sections => Enrollments?.Select(e => e.Section).ToList();

        public float TotalGradePoints => this.CalculateTotalGradePoints();
        public float Cgpa => this.CalculateCgpa();
    }
}