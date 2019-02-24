using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Web.Areas.Admin.Pages.Semesters
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public IndexModel(IUnitOfWork db)
        {
            _db = db;
        }

        public IList<Semester> Semester { get; set; }

        public async Task OnGetAsync()
        {
            Semester = (await _db.Semesters.GetAll()).ToList();
        }
    }
}
