using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.Core;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Web.Areas.FacultyZone.Pages.Schedule
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public IndexModel(IUnitOfWork db)
        {
            _db = db;
        }

        public Faculty Faculty { get; set; }

        public async Task OnGet()
        {
            Faculty = (await _db.Faculties.GetByInitial(User.Identity.Name));
        }
    }
}