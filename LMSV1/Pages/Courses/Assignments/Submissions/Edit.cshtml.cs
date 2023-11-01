using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;

namespace LMSV1.Pages.Courses.Assignments.Submissions
{
    public class EditModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public EditModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Submission Submission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? assId)
        {
            if (id == null || _context.Submissions == null)
            {
                return NotFound();
            }

            var submission =  await _context.Submissions.FirstOrDefaultAsync(m => m.SubmissionID == id);

            if (submission == null)
            {
                return NotFound();
            }

            Submission = submission;
            ViewData["AssignmentID"] = new SelectList(_context.Assignments, "AssignmentID", "Description");
            ViewData["id"] = assId;
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Submission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionExists(Submission.SubmissionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubmissionExists(int id)
        {
          return (_context.Submissions?.Any(e => e.SubmissionID == id)).GetValueOrDefault();
        }
    }
}
