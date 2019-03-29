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

namespace Web.Areas.DepartmentAdmin.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private UserManager<AppUser> UserManager;

        public IndexModel(IUnitOfWork db, UserManager<AppUser> usermanager)
        {
            _db = db;
            UserManager = usermanager;
        }

        public IList<Course> Course { get; set; }

        public async Task OnGetAsync()
        {
            var user = await UserManager.GetUserAsync(User);
            Course = (await _db.Courses.GetAll())
                    .Where(c => c.DepartmentId == user.DepartmentId)
                    .ToList();
        }
    }
}
