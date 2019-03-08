using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


using Data.Core;

using Domain;

using Brotal.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;


namespace Web.Pages.Faculties
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;
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

            var faculty = new Faculty
            {
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Phone = Input.Phone,
                Email = Input.Email,
                Address = Input.Address,
                DepartmentId = Input.DepartmentId,
                Initial = Input.Initial,
                Designation = Input.Designation
            };

            _db.Faculties.Add(faculty);
            await _db.CompleteAsync();

            // Create user
            var user = new AppUser
            {
                Role = Role.Faculty,
                UserName = faculty.Initial,
                Email = faculty.Email
            };

            //var password = Membership.GenerateRandomPassword(
            //    new Brotal.Extensions.PasswordOptions
            //    {
            //        RequiredLength = 8,
            //        RequireDigit = true,
            //        RequireLowercase = true,
            //        RequireUppercase = true,
            //        RequiredUniqueChars = 0,
            //        RequireNonAlphanumeric = true
            //    }
            //);

            var password = "#Arefin555";

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                _logger.LogInformation(
                    $"{User.Identity.Name} created a new Faculty user " +
                    $"with id: {faculty.Initial}, " +
                    $"password: {password}");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = user.Id, code },
                    protocol: Request.Scheme
                );

                await _emailSender.SendEmailAsync(faculty.Email, "Confirm your email",
                    $"Please confirm your account by " +
                    $"<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>" +
                    $"clicking here" +
                    $"</a>.<br/>" +
                    $"Your Student Id/ Username: {faculty.Initial}" +
                    $"Your password is: {password}");

                //await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return RedirectToPage("./Index");
        }


        public class InputModel : Person
        {
            [Required]
            [Display(Name ="Initial")]
            public string Initial { get; set; }

            [Required]
            [Display(Name = "Department")]
            public int DepartmentId { get; set; }

            [Required]
            [Display(Name = "Designation")]
            public string Designation { get; set; }
        }
    }
}