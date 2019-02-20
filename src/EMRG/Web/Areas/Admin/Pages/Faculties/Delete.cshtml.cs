using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Faculties
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DeleteModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Faculty Faculty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Faculty = await _db.Faculties.GetById((int)id);
            if (Faculty == null)
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

            Faculty = await _db.Faculties.GetById((int)id);

            if (Faculty != null)
            {
                Faculty.Meta.Updated(User.Identity.Name);
                await _db.Faculties.Remove((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
