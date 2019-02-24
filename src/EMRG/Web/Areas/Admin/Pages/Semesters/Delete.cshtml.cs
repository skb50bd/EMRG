using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Admin.Pages.Semesters
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DeleteModel(IUnitOfWork db)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _db.Semesters.GetById((int)id);

            if (Semester != null)
            {
                Semester.Meta.Updated(User.Identity.Name);
                await _db.Semesters.Remove((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
