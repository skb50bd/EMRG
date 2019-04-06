﻿using System;
using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Brotal.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.DepartmentAdmin.Pages.Faculties
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private readonly UserManager<AppUser> _userManager;

        public EditModel(IUnitOfWork db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
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
            ViewData["DepartmentId"] = 
                new SelectList(
                    await _db.Departments.GetAll(), 
                    nameof(Department.Id), 
                    nameof(Department.Name));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Faculty.DepartmentId = (int)user.DepartmentId;
            if (!ModelState.IsValid)
            {

                var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
                foreach(ModelError Err in modelStateErrors)
                {
                    System.Diagnostics.Debug.WriteLine(Err.ErrorMessage);
                }
                return Page();
            }

            var original = await _db.Faculties.GetById(Faculty.Id);
            var meta = original.Meta;
            meta.Updated(User.Identity.Name);
            original.SetValuesFrom(Faculty);
            original.Meta = meta;



            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await FacultyExistsAsync(Faculty.Id))
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

        private async Task<bool> FacultyExistsAsync(int id)
        {
            return await _db.Faculties.Exists(id);
        }
    }
}
