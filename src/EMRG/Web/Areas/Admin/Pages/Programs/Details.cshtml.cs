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

namespace Web.Areas.Admin.Pages.Programs
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DetailsModel(IUnitOfWork db)
        {
            _db = db;
        }

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
    }
}
