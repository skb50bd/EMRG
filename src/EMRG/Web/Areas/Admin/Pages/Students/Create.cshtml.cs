using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Brotal.Extensions;

using Data.Core;

using Domain;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Web.Areas.Admin.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<CreateModel> _logger;
        private readonly IEmailSender _emailSender;

        public CreateModel(
            IUnitOfWork db,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<CreateModel> logger,
            IEmailSender emailSender
            )
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["DepartmentId"] =
                new SelectList(
                    await _db.Departments.GetAll(),
                    nameof(Department.Id),
                    nameof(Department.Name));
            ViewData["ProgramId"] =
                new SelectList(
                    await _db.Programs.GetAll(),
                    nameof(Domain.Program.Id),
                    nameof(Domain.Program.Name));
            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var program = await _db.Programs.GetById(Input.ProgramId);
            var students = await _db.Students.Get(
                s => s.StudentId.StartsWith(
                    StudentIdHelper.GetIdPrefix(DateTime.Today, program.Code)),
                s => s.Roll);
            var nextRoll = (students.FirstOrDefault()?.Roll ?? 0) + 1;

            var student = new Student
            {
                FirstName     = Input.FirstName,
                LastName      = Input.LastName,
                Phone         = Input.Phone,
                Email         = Input.Email,
                Address       = Input.Address,
                DepartmentId  = Input.DepartmentId,
                ProgramId     = Input.ProgramId,
                Program       = program,
                AdmissionDate = DateTime.Today,
                DateOfBirth   = Input.DateOfBirth.ParseDate(),
                Roll          = nextRoll,
                Meta          = Metadata.Created(User.Identity.Name)
            };
            _db.Students.Add(student);
            await _db.CompleteAsync();

            // Create user
            var user = new AppUser
            {
                Role = Role.Student,
                UserName = student.StudentId,
                Email = student.Email
            };
            var password = Membership.GenerateRandomPassword(
                new Brotal.Extensions.PasswordOptions
                {
                    RequiredLength = 8,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequiredUniqueChars = 0,
                    RequireNonAlphanumeric = true
                }
            );
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _logger.LogInformation(
                    $"{User.Identity.Name} created a new student user " +
                    $"with id: {student.StudentId}, " +
                    $"password: {password}");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = user.Id, code },
                    protocol: Request.Scheme
                );

                await _emailSender.SendEmailAsync(student.Email, "Confirm your email",
                    $"Please confirm your account by " +
                    $"<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>" +
                    $"clicking here" +
                    $"</a>.<br/>" +
                    $"Your Student Id/ Username: {student.StudentId}" +
                    $"Your password is: {password}");

                //await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return RedirectToPage("./Index");
        }

        public class InputModel : Person
        {
            [Required]
            [Display(Name = "Department")]
            public int DepartmentId { get; set; }

            [Required]
            [Display(Name = "Program")]
            public int ProgramId { get; set; }

            [Required]
            [Display(Name = "Date of Birth")]
            public string DateOfBirth { get; set; }
        }
    }

}