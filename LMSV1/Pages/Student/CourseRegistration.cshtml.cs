using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;

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

        public async Task OnGetAsync(int id)
        {
            CurrentStudent = await _context.Users.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == id);
            Courses = await _context.Courses.ToListAsync();
        }

        public async Task<IActionResult> OnPostRegisterAsync(int studentId, int courseId)
        {
            var enrollment = new Enrollment 
            { 
                UserId = studentId, 
                CourseID = courseId,
                EnrollmentDate = DateTime.Now,
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id = studentId });
        }

        public async Task<IActionResult> OnPostDropAsync(int studentId, int courseId)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.UserId == studentId && e.CourseID == courseId);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { id = studentId });
        }
    }
}
