using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Persistence;
using Domain;
using Data.Core;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.DepartmentAdmin.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private UserManager<AppUser> UserManager;

        public CreateModel(IUnitOfWork db, UserManager<AppUser> usermanager)
        {
            _db = db;
            UserManager = usermanager;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await UserManager.GetUserAsync(User);
            Course.DepartmentId = (int)user.DepartmentId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Course.Meta = Metadata.Created(User.Identity.Name);
            _db.Courses.Add(Course);
            await _db.CompleteAsync();

            return RedirectToPage("./Index");
        }
    }
}