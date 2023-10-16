using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Data;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Pages.Courses.Assignments.Submissions
{
    public class CreateModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        public CreateModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;

        }

        public IActionResult OnGet()
        {
        //ViewData["AssignmentID"] = new SelectList(_context.Assignments, "AssignmentID", "AssignmentID");
        //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Submission Submission { get; set; } = default!;

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "File Name")]
            public string? FileName { get; set; }
            [Display(Name = "Text Submission")]
            public string? TextSubmission { get; set; }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int Assignmentid, int UserID)
        {

            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (!ModelState.IsValid || _context.Submissions == null || Submission == null)
            {
                Submission.AssignmentID = Assignmentid;
                Submission.UserID = UserID;
                Submission.SubmissionDate = DateTime.Now;
            }

            _context.Submissions.Add(Submission);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
