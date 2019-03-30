using System.ComponentModel.DataAnnotations;
using Domain;

namespace Web.Areas.DepartmentAdmin.Pages.Students
{
    public class StudentInputModel : Person
    {
        [Display(Name = "Student Id")]
        public StudentId StudentId { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Program")]
        public int ProgramId { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }
    }
}