using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Core;

using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.DepartmentAdmin.Pages.Faculties
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private readonly UserManager<AppUser> userManager;

        public IndexModel(IUnitOfWork db, UserManager<AppUser> UserManager)
        {
            _db = db;
            userManager = UserManager;
        }

        public IList<Faculty> Faculties { get;set; }

        public async Task OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);

            Faculties = (await _db.Faculties.GetAll())
                        .Where(s => s.DepartmentId == user.DepartmentId)
                        .ToList();
        }
    }
}
