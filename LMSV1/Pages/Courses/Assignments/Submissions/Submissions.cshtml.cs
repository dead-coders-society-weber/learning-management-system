using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.CodeAnalysis.CSharp;
using System.Runtime.CompilerServices;

namespace LMSV1.Pages.Courses.Assignments.Submissions
{
    public class IndexModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public IndexModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        public Course Course { get; set; }
        public IList<Submission> Submission { get;set; } = default!;
        public IList<Enrollment> Enrollment { get; set; } = default!;
        public Assignment Assignment { get; set; }
        // create a list of students that are currently enrolled in the class
        public IList<User> userList = new List<User>();
        // Stores the points earned by the User in the current course
        public double pointsEarned { get; set; }
        // Stores the total points able to be earned by the course
        public double pointsTotal { get; set; }
        // Stores the grade percentage of the course (points earned / points total * 100)
        public double pointsPercentage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? cId)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_context.Courses != null)
            {
                Course = await _context.Courses
                .Include(c => c.Assignments)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseID == cId);
            }
            if (_context.Submissions != null)
            {
                Submission = await _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.User)
                .Where(s => s.AssignmentID == id).ToListAsync();

            }
            if (_context.Assignments != null)
            {
                Assignment = await _context.Assignments
                    .FirstOrDefaultAsync(s => s.AssignmentID == id);
            }
            if (_context.Enrollments != null)
            {
                Enrollment = await _context.Enrollments
                    .Include(s => s.Student)
                    .Where(s => s.CourseID == Course.CourseID).ToListAsync();
            }
            // update the class list for the current course
            foreach (var enrollment in Enrollment)
            {
                userList.Add(enrollment.Student);
            }

            CalculateGradeAsync(userList, Course, Assignment, Submission, Enrollment);

            ViewData["assId"] = id;
            // Submission.First().Assignment.CourseID breaks if _context.Submissions is null,
            // switched to using CourseId parameter passed in from previous page for now
            ViewData["cId"] = Course.CourseID;
            return Page();
        }

        // Calculates the user(student) points earned, total points possible, and grade for the course
        public async Task CalculateGradeAsync(IList<User> classList, Course course, Assignment assignment, IList<Submission> submissions, IList<Enrollment> enrollments)
        {
            // Before updating, Check that the assignment is already past due
            if (submissions != null && (assignment.DueDate < DateTime.Now))
            {

                // if no submissions were made by any student, create a submission for each student with a score of 0
                if (submissions.Count <= 0)
                {
                    foreach (var user in classList)
                    {
                        Submission newSubmission = new Submission
                        {
                            AssignmentID = assignment.AssignmentID,
                            Assignment = assignment,
                            UserID = user.Id,
                            User = user,
                            FileName = "No submission.",
                            TextSubmission = "No submission.",
                            Score = 0,
                            SubmissionDate = DateTime.Now
                        };
                        _context.Submissions.Add(newSubmission);
                        submissions.Add(newSubmission);
                    }
                    // save changes to DB
                    await _context.SaveChangesAsync();
                }
                // iterate through the list of students to update each student's grade
                foreach (var user in classList)
                {
                    // store the enrollment to update the student's grade
                    var enrollment = enrollments.Where(m => m.StudentID == user.Id).FirstOrDefault(m => m.CourseID == course.CourseID);
                    // store the user's submission if any
                    var submission = submissions.FirstOrDefault(m => m.UserID == user.Id);

                    if (enrollment != null)
                    {
                        // if the assignment is past due, but there is not submission by the student, automatically give it 0 points
                        if (submission == null) 
                        {
                            Submission newSubmission = new Submission
                            {
                                AssignmentID = assignment.AssignmentID,
                                Assignment = assignment,
                                UserID = user.Id,
                                User = user,
                                FileName = "No submission.",
                                TextSubmission = "No submission.",
                                Score = 0,
                                SubmissionDate = DateTime.Now
                            };
                            _context.Submissions.Add(newSubmission);
                            submissions.Add(newSubmission);
                            // save changes to DB
                            await _context.SaveChangesAsync();
                        }

                        // Sum the total points earned of all the grades submissions of the student
                        pointsEarned = (double)_context.Submissions
                            .Where(m => Assignment.CourseID == course.CourseID)
                            .Where(m => m.UserID == user.Id)
                            .Sum(m => m.Score);

                        // the max points of the assignment the submissions is for
                        pointsTotal = (double)_context.Assignments
                            .Where(m => m.CourseID == course.CourseID)
                            .Where(m => m.DueDate < DateTime.Now)
                            .Sum(m => m.MaxPoints);

                        // create a percentage of the points earned and max points by dividing and multiply by 100
                        double pointsPercent = pointsEarned / pointsTotal * 100;
                        // round percentage to 2 decimal places
                        pointsPercentage = Math.Round(pointsPercent, 2);


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
                    }
                        
                }
            }
        }
    }
}
