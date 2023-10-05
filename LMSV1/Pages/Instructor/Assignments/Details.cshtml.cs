using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;

namespace LMSV1.Pages.Instructor.Assignments
{
    public class DetailsModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public DetailsModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

      public Assignment Assignment { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignment == null)
            {
                return NotFound();
            }
            else 
            {
                Assignment = assignment;
            }
            return Page();
        }
    }
}
