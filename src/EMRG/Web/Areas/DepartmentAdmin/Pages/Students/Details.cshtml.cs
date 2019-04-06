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
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DetailsModel(IUnitOfWork db)
        {
            _db = db;
        }

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
    }
}
