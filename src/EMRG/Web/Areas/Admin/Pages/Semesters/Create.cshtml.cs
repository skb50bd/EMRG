using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Pages.Semesters
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public CreateModel(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Semester Semester { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Semester.Meta = Metadata.Created(User.Identity.Name);
            _db.Semesters.Add(Semester);

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception e)
            {
                var msg = "Error occured adding semester. Are you adding a duplicate semester?"; 
                Debug.WriteLine(msg + e.Message);
                return BadRequest(msg);
            }

            return RedirectToPage("./Index");
        }
    }
}