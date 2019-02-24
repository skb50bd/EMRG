using System;
using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Brotal.Extensions;

namespace Web.Areas.Admin.Pages.Semesters
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public EditModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Semester Semester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _db.Semesters.GetById((int)id);

            if (Semester == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var original = await _db.Semesters.GetById(Semester.Id);
            var meta = original.Meta;
            meta.Updated(User.Identity.Name);
            original.SetValuesFrom(Semester);
            original.Meta = meta;

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await SemesterExistsAsync(Semester.Id))
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

        private async Task<bool> SemesterExistsAsync(int id)
        {
            return await _db.Semesters.Exists(id);
        }
    }
}
