using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Persistence;
using Domain;
using Data.Core;

namespace Web.Areas.Admin.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DeleteModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _db.Courses.GetById((int)id);
            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _db.Courses.GetById((int)id);

            if (Course != null)
            {
                Course.Meta.Updated(User.Identity.Name);
                await _db.Courses.Remove((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
