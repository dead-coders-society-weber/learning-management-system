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
        private readonly LMSV1.Data.LMSV1Context _context;

        public IndexModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; } = default!;

        public async Task OnGetAsync(int id)
        {
            ViewData["CourseName"] = id;
            if (_context.Assignments != null)
            {
                var courseID = id;
                var Assignments = from A in _context.Assignments
                              select A;
                if (!string.IsNullOrEmpty(courseID.ToString()))
                {
                    Assignments = Assignments.Where(s => s.CourseID == (courseID));
                }

                Assignment = await Assignments.ToListAsync();
            }

        }
    }
}
