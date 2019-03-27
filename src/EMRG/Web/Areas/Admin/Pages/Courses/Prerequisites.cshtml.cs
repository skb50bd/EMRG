using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Brotal.Extensions;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Pages.Courses
{
    public class PrerequisitesModel : PageModel
    {

        private readonly IUnitOfWork _db;

        public PrerequisitesModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Course Course { get; set; }

        [BindProperty]
        public CoursePrerequisite Prerequisite { get; set; }

        [BindProperty]
        public IList<Course> Courses { get; set; }

        [BindProperty]
        public int DeleteId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _db.Courses.GetById((int)id);

            Courses = (await _db.Courses.GetAll()).ToList();

            ViewData["CoursesId"] =
                new SelectList(
                    Courses,
                    nameof(Course.Id),
                    nameof(Course.Code));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Prerequisite.CourseId = Course.Id;
            var original = await _db.Courses.GetById(Course.Id);
            original.Prerequisites.Add(Prerequisite);

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await CourseExistsAsync(Course.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Prerequisites", new { id = Course.Id });
        }

        private async Task<bool> CourseExistsAsync(int id)
        {
            return await _db.Courses.Exists(id);
        }
    }
}