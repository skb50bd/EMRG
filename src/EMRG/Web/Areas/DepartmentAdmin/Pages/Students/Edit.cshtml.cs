using System;
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
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.DepartmentAdmin.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        private UserManager<AppUser> _userManager;

        public EditModel(
            IUnitOfWork db, 
            IMapper mapper,
            UserManager<AppUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        [BindProperty]
        public StudentInputModel Input { get; set; }

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
            //ViewData["DepartmentId"] =
            //    new SelectList(
            //        await _db.Departments.GetAll(),
            //        nameof(Department.Id),
            //        nameof(Department.Name));

            var user = await _userManager.GetUserAsync(User);

            ViewData["ProgramId"] =
                new SelectList(
                    (await _db.Programs.GetAll()).Where(s => s.DepartmentId == user.DepartmentId),
                    nameof(Domain.Program.Id),
                    nameof(Domain.Program.Name));

            Input = _mapper.Map<StudentInputModel>(Student);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Student = _mapper.Map<Student>(Input);
            var original = await _db.Students.GetById(Input.Id);
            var meta = original.Meta;
            meta.Updated(User.Identity.Name);
            Student.AdmissionDate = original.AdmissionDate;
            Student.StudentId = original.StudentId;

            original.SetValuesFrom(Student);
            original.Meta = meta;

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await StudentExistsAsync(Student.Id))
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

        private async Task<bool> StudentExistsAsync(int id)
        {
            return await _db.Students.Exists(id);
        }
    }
}
