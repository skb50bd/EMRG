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
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public IndexModel(IUnitOfWork db)
        {
            _db = db;
        }

        public IList<Course> Course { get; set; }

        public async Task OnGetAsync()
        {
            Course = (await _db.Courses.GetAll()).ToList();
        }
    }
}
