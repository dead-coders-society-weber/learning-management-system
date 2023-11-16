using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LMSV1.Pages.Courses
{
    public class CourseHomeModel : PageModel
    {
        //Reference to the database
        private readonly LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        //Allows us to use the database
        public CourseHomeModel(LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Grabs a list of items and stores them inside a list
        public Course? Course { get; set; } = default!;
        // Store the currently logged in user
        public User? user { get; set; }

        // Stores the points earned by the User in the current course
        public double? pointsEarned { get; set; }
        // Stores the total points able to be earned by the course
        public double? pointsTotal { get; set; }
        // Stores the grade percentage of the course (points earned / points total * 100)
        public double? pointsPercentage { get; set; }
        // Stores the grade earned for the course
        public string finalGrade { get; set; }
        public IList<string> Grades { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //Set the signed in user information the this variable
            user = await _userManager.GetUserAsync(User);

            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                .Include(c => c.Assignments)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }

            //If a user is an instructor, prepoplulate the variables for the instructors chart.
            if (user.Role == "Instructor")
            {
                Grades = await _context.Enrollments
                               .Where(e => e.CourseID == id)
                               .Select(e => e.Grade)
                               .ToListAsync();
            }

            // If user is a student, populate variables for the students grade chart.
            // By default, if the instructor hasn't updated grades, the student will have full points
            if (user.Role == "Student")
            {
                Grades = await _context.Enrollments
                           .Where(e => e.CourseID == id)
                           .Select(e => e.Grade)
                           .ToListAsync();
                Enrollment enrollment = await _context.Enrollments
                    .Where(e => e.StudentID == user.Id).FirstOrDefaultAsync(e => e.CourseID == id);
                // Display the max points possible in the class
                pointsTotal = Course.Assignments.Where(m => m.DueDate < DateTime.Now).Sum(m => m.MaxPoints);

                // display Grade percentage
                if (enrollment.GradePercentage == null)
                {
                    pointsPercentage = 100;
                }
                else
                {
                    enrollment.GradePercentage = Math.Round((double)(enrollment.PointsEarned / pointsTotal),4) * 100;
                    pointsPercentage = enrollment.GradePercentage;
                }
                // display Points the Student has earned so far
                if (enrollment.PointsEarned == null)
                {
                    pointsEarned = pointsTotal;
                }
                else
                {
                    pointsEarned = enrollment.PointsEarned;
                }
                // Display the Grade the Student has earned so far
                if (enrollment.Grade == null)
                {
                    finalGrade = "A";
                }
                else
                {
                    // using syllabus for the class, update the student's grade for the course
                    enrollment.GradePercentage = pointsPercentage;
                    enrollment.PointsEarned = pointsEarned;
                    switch (pointsPercentage)
                    {
                        case var n when (n >= 94.00):
                            enrollment.Grade = "A";
                            break;
                        case var n when (n >= 90.00 && n < 94.00):
                            enrollment.Grade = "A-";
                            break;
                        case var n when (n >= 87.00 && n < 90.00):
                            enrollment.Grade = "B+";
                            break;
                        case var n when (n >= 84.00 && n < 87.00):
                            enrollment.Grade = "B";
                            break;
                        case var n when (n >= 80.00 && n < 84.00):
                            enrollment.Grade = "B-";
                            break;
                        case var n when (n >= 77.00 && n < 80.00):
                            enrollment.Grade = "C+";
                            break;
                        case var n when (n >= 74.00 && n < 77.00):
                            enrollment.Grade = "C";
                            break;
                        case var n when (n >= 70.00 && n < 74.00):
                            enrollment.Grade = "C-";
                            break;
                        case var n when (n >= 67.00 && n < 70.00):
                            enrollment.Grade = "D+";
                            break;
                        case var n when (n >= 64.00 && n < 67.00):
                            enrollment.Grade = "D";
                            break;
                        case var n when (n >= 60.00 && n < 64.00):
                            enrollment.Grade = "D-";
                            break;
                        default:
                            enrollment.Grade = "E";
                            break;
                    }
                    // save changes to DB
                    await _context.SaveChangesAsync();
                    finalGrade = enrollment.Grade;
                }

            }
            return Page();
        }

    }
}
