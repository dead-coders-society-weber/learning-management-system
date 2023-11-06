using LMSV1.Data;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LMSV1.Pages
{
    public class IndexModel : PageModel
    {
        //Created to reference the database
        private readonly LMSV1.Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        private readonly IMemoryCache _memoryCache;

        //Allows us to look at the database and reference information inside of it
        public IndexModel(LMSV1.Data.LMSV1Context context, UserManager<User> userManager,
            IMemoryCache memoryCache)
        {
            _context = context;
            _userManager = userManager;
            _memoryCache = memoryCache;
        }

        //A list created of the course information, considering that there are multiple courses
        //we need to use the IList<Course> way of referencing so that we can use an array
        public IList<Course> Courses { get; set; } = default!;

        // A list for assignments to do
        public IList<Assignment> Assignments { get; set; }

        //This method will get the information from the database
        //Because it is an Async method it will not wait for the data to be gathered before allowing
        //the user to continue with operations, this helps with optimization.
        public async Task<IActionResult> OnGetAsync()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                // get courses
                Courses = await GetCoursesCache(user);

                // get all assignments from enrolled courses
                Assignments = await _context.Enrollments
                    .Where(e => e.StudentID == user.Id)
                    .SelectMany(e => e.Course.Assignments)
                    .Where(a => a.DueDate >= DateTime.Now)
                    .OrderBy(a => a.DueDate)
                    .Include(a => a.Course)
                    .ToListAsync();
            }

            return Page();
        }

        public async Task<IList<Course>> GetCoursesCache(User user)
        {
            var courses = _memoryCache.Get<IList<Course>>("courses_" + user.Id.ToString());

            if(courses == null)
            {
                if (user.Role == "Instructor")
                {
                    courses = await _context.Courses
                        .Where(c => c.InstructorID == user.Id)
                        .ToListAsync();
                }

                if (user.Role == "Student")
                {
                    // get only courses the user is enrolled in
                    courses = await _context.Enrollments
                        .Where(e => e.StudentID == user.Id)
                        .Select(e => e.Course)
                        .ToListAsync();
                }

                _memoryCache.Set("courses", courses, TimeSpan.FromDays(5));
            }

            return courses;
        }
    }
}