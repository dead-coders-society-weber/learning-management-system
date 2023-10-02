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

namespace LMSV1.Pages.Instructor
{
    public class IndexModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(Data.LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<Course> Course { get;set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                var user = await _userManager.GetUserAsync(User);

                    var courses = from c in _context.Courses
                                 select c;
                    if (!string.IsNullOrEmpty(user.Id.ToString()))
                    {
                        courses = courses.Where(s => s.InstructorID == (user.Id));
                    }

                    Course = await courses.ToListAsync();
            }
        }
    }
}
