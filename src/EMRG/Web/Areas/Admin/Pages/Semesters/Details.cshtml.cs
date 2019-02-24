using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Admin.Pages.Semesters
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DetailsModel(IUnitOfWork db)
        {
            _db = db;
        }

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
    }
}
