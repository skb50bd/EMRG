﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Persistence;
using Domain;
using Data.Core;

namespace Web.Areas.Admin.Pages.Students
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
            ViewData["ProgramId"] =
                new SelectList(
                    await _db.Programs.GetAll(),
                    nameof(Domain.Program.Id),
                    nameof(Domain.Program.Name));
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Student.Meta = Metadata.Created(User.Identity.Name);
            _db.Students.Add(Student);
            await _db.CompleteAsync();

            return RedirectToPage("./Index");
        }
    }
}