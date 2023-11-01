using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;

namespace LMSV1.Pages.Courses.Assignments
{
    public class AssignmentDeleteModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public AssignmentDeleteModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            // Query the Assignment and any Submissions from DB
            var assignment = await _context.Assignments.FindAsync(id);

            // Uncomment if submissions need to be deleted if the assignment is deleted
            //var submissionsToDelete = _context.Submissions.Where(e => e.AssignmentID == id).ToList();

            // Remove assignment from DB
            if (assignment != null)
            {
                Assignment = assignment;
                _context.Assignments.Remove(Assignment);
            }

            // Remove any submissions for assignment, uncomment if we decide to delete submissions, once the assignment is deleted
            //if (submissionsToDelete.Any())
            //{
            //    _context.Submissions.RemoveRange(submissionsToDelete);
            //}

            await _context.SaveChangesAsync();

            return RedirectToPage("./SuccessPage");
        }
    }
}
