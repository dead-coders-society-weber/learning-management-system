using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

namespace LMSV1.Pages.Courses
{
    public class CourseEditModel : PageModel
    {
        private readonly Data.LMSV1Context _context;

        public CourseEditModel(Data.LMSV1Context context)
        {
            _context = context;
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

        private async Task LoadAsync(Course course)
        {
            // get list of departments
            var deptQuery = from d in _context.Departments
                            orderby d.Name
                            select d;
            Departments = new SelectList(deptQuery.AsNoTracking(),
                nameof(Department.DepartmentID),
                nameof(Department.Name));

            // populate the fields
            Input = new InputModel
            {
                DepartmentID = course.DepartmentID,
                CourseID = course.CourseID,
                Title = course.Title,
                Credits = course.Credits,
                Location = course.Location,
                MeetDays = course.MeetDays,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
            };
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course =  await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            await LoadAsync(course);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound($"Unable to load course with ID '{id}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(course);
                return Page();
            }

            course.DepartmentID = Input.DepartmentID;
            course.CourseID = Input.CourseID;
            course.Title = Input.Title;
            course.Credits = Input.Credits;
            course.Location = Input.Location;
            course.MeetDays = SelectedDays.Aggregate(DaysOfWeek.None, (current, day) => current | (DaysOfWeek)day);
            course.StartTime = Input.StartTime;
            course.EndTime = Input.EndTime;

            _context.Attach(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(course.CourseID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Instructor/CourseManager");
        }

        private bool CourseExists(int id)
        {
          return (_context.Courses?.Any(e => e.CourseID == id)).GetValueOrDefault();
        }
    }
}
