using LMSV1.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;

namespace LMSV1.Areas.Identity.Pages.Account
{
    public class InstructorCourseCreationModel : PageModel
    {

        //private readonly SignInManager<CourseCreation> _signInManager;
        private readonly UserManager<CourseCreation> _userManager;
        //private readonly IUserStore<CourseCreation> _userStore;
       // private readonly IUserEmailStore<CourseCreation> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
       // private readonly IEmailSender _emailSender;

        public InstructorCourseCreationModel(
           /* UserManager<CourseCreation> userManager,
            IUserStore<CourseCreation> userStore,
            SignInManager<CourseCreation> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender*/)
        {
            /*_userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;*/
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Course ID")]
            public required string CourseID { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            //[DataType(DataType.Password)]
            [Display(Name = "Course Name")]
            public required string CourseName { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Credit Hours")]
            public required string CreditHours { get; set; }

            [Required]
            [Display(Name = "Location")]
            public required string Location { get; set; }

            [Required]
            [Display(Name = "Days to Meet")]
            public required string MeetTimes { get; set; }

            [Required]
            [Display(Name = "Start and End Time")]
            [DataType(DataType.Date)]
            public required string StartEndTimes { get; set; }

            [Required]
            public string? Instructor { get; set; }
        }


        public void OnGet(string? returnUrl = null)
        {
            //ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var course = CreateCourse();

                course.CourseID = Input.CourseID;
                course.CourseName = Input.CourseName;
                course.CreditHours = Input.CreditHours;
                course.Location = Input.Location;
                course.MeetDays = Input.MeetTimes;
                course.StartEndTimes = Input.StartEndTimes;

              
                var result = await _userManager.CreateAsync(course, Input.CourseID);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Course has successfully been created.");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            // If we got this far, something failed, redisplay form
            return Page();
        }

        private CourseCreation CreateCourse()
        {
            try
            {
                return Activator.CreateInstance<CourseCreation>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(CourseCreation)}'. " +
                    $"Ensure that '{nameof(CourseCreation)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/InstructorCourseCreation.cshtml");
            }
        }
    }
}
