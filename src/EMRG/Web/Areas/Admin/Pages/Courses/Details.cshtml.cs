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

namespace Web.Areas.Admin.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DetailsModel(IUnitOfWork db)
        {
            _db = db;
        }

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
            return Page();
        }
    }
}
