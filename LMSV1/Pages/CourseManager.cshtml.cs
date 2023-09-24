using LMSV1.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;


namespace LMSV1.Pages
{
    public class CourseManagerModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1UserContext _context;

        public CourseManagerModel(LMSV1.Data.LMSV1UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<Course> Course { get; set; } = default!;

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
            [Display(Name = "Start Time")]
            [DataType(DataType.Date)]
            public required string StartTime { get; set; }

            [Required]
            [Display(Name = "End Time")]
            [DataType(DataType.Date)]
            public required string EndTime { get => StartTime; set => StartTime = value; }

            [Required]
            public string? Instructor { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

 
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid || _context.Course == null || Course == null)
        //    {
        //        return Page();
        //    }

        //    _context.Course.Add(Course);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
        //public async Task OnGetAsync()
        //{
        //    if (_context.Course != null)
        //    {
        //        Course = await _context.Course.ToListAsync();
        //    }
        //}

        public Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var course = CreateCourse();

                course.CourseID = Input.CourseID;
                course.Title = Input.CourseName;
                course.Credits = Input.CreditHours;
                course.Location = Input.Location;
                course.MeetDays = Input.MeetTimes;
                course.StartTime = Input.StartTime;
                course.EndTime = Input.EndTime;
            }


            // If we got this far, something failed, redisplay form
            return Task.FromResult<IActionResult>(Page());
        }

        private Course CreateCourse()
        {
            try
            {
                return Activator.CreateInstance<Course>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Course)}'. " +
                    $"Ensure that '{nameof(Course)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/InstructorCourseCreation.cshtml");
            }
        }
    }
}


