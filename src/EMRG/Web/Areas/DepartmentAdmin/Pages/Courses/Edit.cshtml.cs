﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Persistence;
using Domain;
using Data.Core;
using Brotal.Extensions;
using Microsoft.AspNetCore.Identity;


namespace Web.Areas.DepartmentAdmin.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private readonly UserManager<AppUser> userManager;

        public EditModel(IUnitOfWork db, UserManager<AppUser> UserManager)
        {
            _db = db;
            userManager = UserManager;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _db.Courses.GetById((int)id);

            if (Course == null)
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
            var user = await userManager.GetUserAsync(User);
            Course.DepartmentId = (int)user.DepartmentId;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var original = await _db.Courses.GetById(Course.Id);
            var meta = original.Meta;
            meta.Updated(User.Identity.Name);
            original.SetValuesFrom(Course);
            original.Meta = meta;

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await CourseExistsAsync(Course.Id))
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

        private async Task<bool> CourseExistsAsync(int id)
        {
            return await _db.Courses.Exists(id);
        }
    }
}
