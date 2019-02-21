using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Persistence;
using Data.Core;
using Domain;
using Brotal.Extensions;

namespace Web.Areas.Admin.Pages.Programs
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public EditModel(IUnitOfWork db)
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
            ViewData["DepartmentId"] =
                new SelectList(
                    await _db.Departments.GetAll(),
                    nameof(Department.Id),
                    nameof(Department.Name));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var original = await _db.Programs.GetById(Program.Id);
            var meta = original.Meta;
            meta.Updated(User.Identity.Name);
            original.SetValuesFrom(Program);
            original.Meta = meta;

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await ProgramExistsAsync(Program.Id))
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

        private async Task<bool> ProgramExistsAsync(int id)
        {
            return await _db.Programs.Exists(id);
        }
    }
}
