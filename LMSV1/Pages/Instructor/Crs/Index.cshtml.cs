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

namespace LMSV1.Pages.Instructor.Crs
{
    public class IndexModel : PageModel
    {
        //Reference to the database
        private readonly LMSV1.Data.LMSV1Context _context;

        //Allows us to use the database
        public IndexModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        //Grabs a list of items and stores them inside a list
        public Course? Course { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                .Include(c => c.Assignments)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseID == id);

            if(Course == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
