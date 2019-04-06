using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Brotal.Extensions;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Areas.Admin.Pages.Programs
{
    public class EditCourseModel : PageModel
    {

        private readonly IUnitOfWork _db;

        public EditCourseModel(IUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty]
        public Domain.Program Program { get; set; }

        [BindProperty]
        public IList<Course> Courses { get; set; }

        [BindProperty]
        public IList<ProgramCourse> ProgramCourses { get; set; }

        [BindProperty]
        public ProgramCourse AddedCourses { get; set; }

        [BindProperty]
        public IList<ProgramCourse> AddedCompolsoryCourses { get; set; }

        [BindProperty]
        public IList<ProgramCourse> AddedOptionalCourses { get; set; }

        [BindProperty]
        public int DeleteId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Program = await _db.Programs.GetById((int)id);

            AddedCompolsoryCourses = Program.Courses
                .Where(c => c.IsOptional == false)
                .ToList();
            AddedOptionalCourses = Program.Courses
                .Where(c => c.IsOptional == true)
                .ToList(); ;

            Courses = (await _db.Courses.GetAll()).ToList();

            ViewData["CoursesId"] =
                new SelectList(
                    Courses,
                    nameof(Course.Id),
                    nameof(Course.Code));

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    ProgramCourse.program = Program;

        //    Program.ProgramCourses.Add(ProgramCourse);

        //    var original = await _db.Programs.GetById(Program.Id);
        //    /* var meta = new Metadata()*/
        //    ;
        //    //meta.Updated(User.Identity.Name);
        //    original.SetValuesFrom(Program);
        //    //original.Meta = meta;


        //    try
        //    {
        //        await _db.CompleteAsync();
        //    }
        //    catch (Exception)
        //    {
        //        if (!await ProgramExistsAsync(Program.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        public async Task<IActionResult> OnPostComplosoryCourseAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            AddedCourses.IsOptional = false;
            AddedCourses.ProgramId = Program.Id;

            var original = await _db.Programs.GetById(Program.Id);
            //var meta = original.Meta;
            //meta.Updated("sss");
            //original.SetValuesFrom(Program);
            original.Courses.Add(AddedCourses);
            //original.Meta = meta;

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await ProgramExistsAsync(Program.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./EditCourse", new { id = Program.Id });
        }



        public async Task<IActionResult> OnPostOptionalCourseAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            AddedCourses.IsOptional = true;
            AddedCourses.ProgramId = Program.Id;

            var original = await _db.Programs.GetById(Program.Id);
            //var meta = original.Meta;
            //meta.Updated("sss");
            original.Courses.Add(AddedCourses);
            //original.Meta = meta;

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await ProgramExistsAsync(Program.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("./EditCourse", new { id = Program.Id });
        }


        public async Task<IActionResult> OnPostDeleteCourseAsync()
        {
            var original = await _db.Programs.GetById(Program.Id);

            original.Courses.RemoveAll(x => x.CourseId == DeleteId);

            try
            {
                await _db.CompleteAsync();
            }
            catch (Exception)
            {
                if (!await ProgramExistsAsync(Program.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./EditCourse", new { id = Program.Id });
        }

        private async Task<bool> ProgramExistsAsync(int id)
        {
            return await _db.Programs.Exists(id);
        }
    }
}