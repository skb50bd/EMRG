using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Persistence;
using Domain;

namespace Web.Areas.Admin.Pages.Sections
{
    public class CreateModel : PageModel
    {
        private readonly Data.Persistence.AppDbContext _context;

        public CreateModel(Data.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", nameof(Course.Code));
        ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", nameof(Faculty.Initial));
        ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", nameof(Room.Number));
        ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", nameof(Semester.Name));
            return Page();
        }

        [BindProperty]
        public Section Section { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sections.Add(Section);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}