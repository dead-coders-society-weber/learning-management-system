using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Pages.Courses
{
    public class CourseCreateModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        public CourseCreateModel(Data.LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Course ID is required.")]
            [Display(Name = "Course ID")]
            public int CourseID { get; set; }

            [Required(ErrorMessage = "Course Name is required.")]
            [StringLength(100)]
            [Display(Name = "Course Name")]
            public required string Title { get; set; }

            [Required(ErrorMessage = "Credit hours is required.")]
            [Display(Name = "Credit Hours")]
            [Range(0, 5)]
            public int Credits { get; set; }

            [Required(ErrorMessage = "Location is required.")]
            [Display(Name = "Location")]
            public string Location { get; set; }

            [Required(ErrorMessage = "Meeting times is required.")]
            [Display(Name = "Meet Times")]
            public DaysOfWeek MeetDays { get; set; }

            [Required(ErrorMessage = "Start time is required.")]
            [Display(Name = "Start Time")]
            [DataType(DataType.Time)]
            public TimeSpan StartTime { get; set; }

            [Required(ErrorMessage = "End time is required.")]
            [Display(Name = "End Time")]
            [DataType(DataType.Time)]
            public TimeSpan EndTime { get; set; }

            [Required(ErrorMessage = "Department is required")]
            [Display(Name = "Department")]
            public string DepartmentID { get; set; }
        }

        [BindProperty]
        public List<int> SelectedDays { get; set; } = new List<int>();

        public SelectList Departments { get; set; }

        public int instructorID { get; set; }

        public IActionResult OnGet()
        {
            var deptQuery = from d in _context.Departments
                            orderby d.Name
                            select d;
            Departments = new SelectList(deptQuery.AsNoTracking(),
                nameof(Department.DepartmentID),
                nameof(Department.Name));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int instructorId)
        {
            if (ModelState.IsValid)
            {
                var newCourse = new Course
                {
                    CourseID = Input.CourseID,
                    Title = Input.Title,
                    Credits = Input.Credits,
                    Location = Input.Location,
                    MeetDays = SelectedDays.Aggregate(DaysOfWeek.None, (current, day) => current | (DaysOfWeek)day),
                    StartTime = Input.StartTime,
                    EndTime = Input.EndTime,
                    DepartmentID = Input.DepartmentID,
                    InstructorID = instructorId
                };

                _context.Courses.Add(newCourse);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Instructor/CourseManager");
            }

            return Page();
        }
    }
}
