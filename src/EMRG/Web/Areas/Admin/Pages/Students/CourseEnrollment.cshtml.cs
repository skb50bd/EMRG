using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.Core;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Pages.Students
{
    public class CourseEnrollmentModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public CourseEnrollmentModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public IList<Course> Courses { get; set; }

        [BindProperty]
        public Course Course { get; set; }

        [BindProperty]
        public Section Section { get; set; }

        [BindProperty]
        public IList<Semester> Semesters { get; set; }

        [BindProperty]
        public Semester Semester { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Semesters = (await _db.Semesters.GetAll()).ToList();
            Courses = (await _db.Courses.GetAll()).ToList();
            Student = await _db.Students.GetById((int)id);

            ViewData["CourseId"] =
                new SelectList(
                    Courses,
                    nameof(Course.Id),
                    nameof(Course.Code));
            ViewData["SemesterId"] =
                new SelectList(
                    Semesters,
                    nameof(Semester.Id),
                    nameof(Semester.Name));


            return Page();
        }
    }
}