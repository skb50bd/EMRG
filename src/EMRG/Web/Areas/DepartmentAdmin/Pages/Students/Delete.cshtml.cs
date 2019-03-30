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

namespace Web.Areas.DepartmentAdmin.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DeleteModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _db.Students.GetById((int)id);
            if (Student == null)
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

            Student = await _db.Students.GetById((int)id);

            if (Student != null)
            {
                Student.Meta.Updated(User.Identity.Name);
                await _db.Students.Remove((int)id);

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
