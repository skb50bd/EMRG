using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Persistence;
using Domain;

namespace Web.Areas.DepartmentAdmin.Pages.Sections
{
    public class EditModel : PageModel
    {
        private readonly Data.Persistence.AppDbContext _context;

        public EditModel(Data.Persistence.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Section Section { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Section = await _context.Sections
                .Include(s => s.Course)
                .Include(s => s.Faculty)
                .Include(s => s.Room)
                .Include(s => s.Semester).FirstOrDefaultAsync(m => m.Id == id);

            if (Section == null)
            {
                return NotFound();
            }
           ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
           ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id");
           ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
           ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Section).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(Section.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.Id == id);
        }
    }
}
