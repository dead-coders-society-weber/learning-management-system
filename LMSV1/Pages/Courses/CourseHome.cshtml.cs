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
        public User? user {  get; set; }
        // Stores the points earned by the User in the current course
        public double pointsEarned { get; set; }
        // Stores the total points able to be earned by the course
        public double pointsTotal { get; set; }
        // Stores the grade percentage of the course (points earned / points total * 100)
        public double pointsPercentage { get; set; }
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
            
            // If user is a student, show their points and grade for the course
            if (user.Role == "Student")
            {
                CalculateGrade(id, user);
            }
            //If a user is an instructor, prepoplulate the variables for the instructorschart.
            if (user.Role == "Instructor")
            { 
                Grades = await _context.Enrollments
                               .Where(e => e.CourseID == id)
                               .Select(e => e.Grade)
                               .ToListAsync();
            }

            return Page();
        }

        // Prepoluate the Instructor Chart.
        // Calculates the user(student) points earned, total points possible, and grade for the course
        public void CalculateGrade(int? cid, User user)
        {
            // Sum the total points earned of all the grades submissions of the student
            pointsEarned = (double)_context.Submissions
                .Where(m => m.UserID == user.Id)
                .Sum(m => m.Score);

            // Sum the total max points of all assignments of the course, only for assignments pass the due date, which is when they'll be graded
            pointsTotal = (double)_context.Assignments
                .Where(m => m.CourseID == Course.CourseID)
                .Where(m => m.DueDate <  DateTime.Now)
                .Sum(m => m.MaxPoints);

            // create a percentage of the points earned and max points by dividing and multiply by 100
            double pointsPercent = pointsEarned / pointsTotal * 100;
            // round percentage to 2 decimal places
            pointsPercentage = Math.Round(pointsPercent, 2);

            // store the enrollment to update the student's grade
            var enrollment = _context.Enrollments.Where(m => m.StudentID == user.Id).FirstOrDefault(m => m.CourseID == cid);
            // using syllabus for the class, update the student's grade for the course
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
            // store it in the model for display
            finalGrade = enrollment.Grade;
            // save changes to DB
            _context.SaveChangesAsync();
        }
    }
}
