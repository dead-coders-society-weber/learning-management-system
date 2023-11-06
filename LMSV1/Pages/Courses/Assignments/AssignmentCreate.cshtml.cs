using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Data;
using LMSV1.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LMSV1.Pages.Courses.Assignments
{
    public class AssignmentCreateModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public AssignmentCreateModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Assignment Name is required.")]
            [StringLength(100, MinimumLength = 4, ErrorMessage = "Assignment name must be between 4 and 100 characters.")]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Description is required.")]
            [StringLength(100, MinimumLength = 5, ErrorMessage = "Assignment name must be between 5 and 100 characters.")]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Maximum points is required.")]
            [Display(Name = "Max Points")]
            public int MaxPoints { get; set; }

            [Required(ErrorMessage = "Due date is required.")]
            [Display(Name = "Due Date")]
            [DataType(DataType.DateTime)]
            public DateTime DueDate { get; set; }

            [Required(ErrorMessage = "Submission Type is required.")]
            [Display(Name = "Submission Type")]
            public SubmissionType SubmissionType { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                // create new assignment
                var newAssignment = new Assignment
                {
                    CourseID = id,
                    Course = _context.Courses.FirstOrDefault(x => x.CourseID == id),
                    Title = Input.Title,
                    Description = Input.Description,
                    MaxPoints = Input.MaxPoints,
                    DueDate = Input.DueDate,
                    SubmissionType = Input.SubmissionType,
                };

                var assignment = _context.Assignments.Add(newAssignment);
                await _context.SaveChangesAsync();

                // create new notification for all students in course
                var enrollments = await _context.Enrollments
                                        .Where(e => e.CourseID == id)
                                        .Include(e => e.Student)
                                        .ToListAsync();
                enrollments.ForEach(async enrollment =>
                {
                    var newNotification = new Notification
                    {
                        Event = NotificationEvent.AssignmentCreation,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        StudentID = enrollment.StudentID,
                        Student = enrollment.Student,
                        AssignmentID = assignment.Entity.AssignmentID,
                        Assignment = assignment.Entity
                    };

                    _context.Notifications.Add(newNotification);
                });

                await _context.SaveChangesAsync();
                return RedirectToPage("./SuccessPage");
            }

            return Page();
        }
    }
}
