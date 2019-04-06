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
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.DepartmentAdmin.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private UserManager<AppUser> _userManager;

        public IndexModel(IUnitOfWork db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IList<Student> Student { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            Student = (await _db.Students.GetAll())
                        .Where(s=> s.DepartmentId == user.DepartmentId)
                        .ToList();
        }
    }
}
