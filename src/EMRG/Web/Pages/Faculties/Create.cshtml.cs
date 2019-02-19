using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Faculties
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public CreateModel(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["DepartmentId"] = 
                new SelectList(
                    await _db.Departments.GetAll(), 
                    nameof(Department.Id), 
                    nameof(Department.Name));
            return Page();
        }

        [BindProperty]
        public Faculty Faculty { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Faculties.Add(Faculty);
            await _db.CompleteAsync();

            return RedirectToPage("./Index");
        }
    }
}