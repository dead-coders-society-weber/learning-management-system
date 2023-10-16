using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;

namespace LMSV1.Pages.Courses.Assignments.Submissions
{
    public class DetailsModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public DetailsModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

      public Submission Submission { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Submissions == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions.FirstOrDefaultAsync(m => m.SubmissionID == id);
            if (submission == null)
            {
                return NotFound();
            }
            else 
            {
                Submission = submission;
            }
            return Page();
        }
    }
}
