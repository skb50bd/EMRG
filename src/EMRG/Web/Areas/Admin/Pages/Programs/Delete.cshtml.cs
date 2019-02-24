using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Core;
using Data.Persistence;
using Domain;

namespace Web.Areas.Admin.Pages.Programs
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DeleteModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Domain.Program Program { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Program = await _db.Programs.GetById((int)id);
            if (Program == null)
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

            Program = await _db.Programs.GetById((int)id);

            if (Program != null)
            {
                Program.Meta.Updated(User.Identity.Name);
                await _db.Programs.Remove((int)id);

                try
                {
                    await _db.CompleteAsync();
                }
                catch (Exception)
                {
                    
                    throw;
                    
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
