using System.Collections.Generic;
using System.Threading.Tasks;

using Domain;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Admin.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly Data.Persistence.AppDbContext _context;

        public IndexModel(Data.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _context.Departments.ToListAsync();
        }
    }
}
