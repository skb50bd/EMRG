using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Persistence;
using Domain;

namespace Web.Pages.Faculties
{
    public class DetailsModel : PageModel
    {
        private readonly Data.Persistence.AppDbContext _context;

        public DetailsModel(Data.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public Faculty Faculty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Faculty = await _context.Faculties
                .Include(f => f.Department).FirstOrDefaultAsync(m => m.Id == id);

            if (Faculty == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
