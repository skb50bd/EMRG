using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.DepartmentAdmin.Pages.Faculties
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DetailsModel(IUnitOfWork db)
        {
            _db = db;
        }

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
    }
}
