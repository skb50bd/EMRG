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

        [BindProperty]
        public CourseEnrollment Enrollment { get; set; }

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


        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Enrollment.StudentId = Student.Id;

            var original = await _db.Students.GetById(Student.Id);

            original.Enrollments.Add(Enrollment);



            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await StudentExistsAsync(Student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CourseEnrollment", new { id = Student.Id });
        }


        public async Task<IActionResult> OnPostDeleteEnrollmentAsync()
        {
            //var original = await _db.Students.GetById(Student.Id);

            //original.Enrollments.RemoveAll(x => x.Id == Enrollment.Id);

            await _db.CourseEnrollments.Delete(Enrollment.Id);

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await StudentExistsAsync(Student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CourseEnrollment", new { id = Student.Id });


        }


        private async Task<bool> StudentExistsAsync(int id)
        {
            return await _db.Students.Exists(id);
        }
    }
}