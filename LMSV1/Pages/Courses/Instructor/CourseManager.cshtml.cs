using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMSV1.Pages.Courses.Instructor
{
    public class CourseManagerModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        public CourseManagerModel(Data.LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Course> Courses { get; set; } = default!;
        public int instructorID { get; set; }

        public async Task OnGetAsync()
        {
            // Get the current user (instructor)
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                // Fetch courses where the user is the instructor
                Courses = await _context.Courses
                    .Where(c => c.InstructorID == user.Id)
                    .ToListAsync();

                // set the instructorID
                instructorID = user.Id;
            }
        }
    }
}
