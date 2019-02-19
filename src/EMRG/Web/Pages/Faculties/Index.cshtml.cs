using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Faculties
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public IndexModel(IUnitOfWork db)
        {
            _db = db;
        }

        public IList<Faculty> Faculties { get;set; }

        public async Task OnGetAsync()
        {
            Faculties = (await _db.Faculties.GetAll()).ToList();
        }
    }
}
