﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace LMSV1.Pages.Student
{
    public class CourseRegistrationModel : PageModel
    {
        private readonly LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        public CourseRegistrationModel(LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Course> Courses { get; set; }
        public User CurrentStudent { get; private set; }

        // On page load:
        public async Task OnGetAsync(int id)
        {
            // Load the currently logged user and their ienrollments from the DB using an ID query 
            CurrentStudent = await _context.Users.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == id);

            // Load the list of Courses availabe for students
            Courses = await _context.Courses.ToListAsync();
        }

        // Method for when the user clicks Register on a Course in the Course Registration List 
        public async Task<IActionResult> OnPostRegisterAsync(int studentId, int courseId)
        {
            // Create an enrollment object by passing in the:
            // Currently logged in student,
            // Course ID of the Course the student has registered for,
            // Set the Enrollment date to the current date/time from the server.
            var enrollment = new Enrollment 
            { 
                UserId = studentId, 
                CourseID = courseId,
                EnrollmentDate = DateTime.Now,
                Role = Role.Student,
            };
            
            // Add the enrollment to the Enrollments table in the DB
            _context.Enrollments.Add(enrollment);

            // Save the changes in the DB
            await _context.SaveChangesAsync();

            // Redirect back to the current page,
            // passing in the currently logged in student's id to update
            // the display of the current student's course registration list
            return RedirectToPage(new { id = studentId });
        }

        // Method for when the student clicks Drop on a Course in the Course Registration List
        public async Task<IActionResult> OnPostDropAsync(int studentId, int courseId)
        {
            // Create an enrollment object using a DB query by filtering:
            // User ID and Course ID
            // If the enrollment exists:
            // Remove it from the DB and save the changes to the DB
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.UserId == studentId && e.CourseID == courseId);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }

            // Redirect back to the current page,
            // passing in the currently logged in student's id to update
            // the display of the current student's course registration list
            return RedirectToPage(new { id = studentId });
        }
    }
}