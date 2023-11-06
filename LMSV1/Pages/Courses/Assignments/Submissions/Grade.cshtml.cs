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
using System.IO;
using NuGet.ContentModel;

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
        // OnGet method
        // submission and assignment id are passed from previous page
        public async Task<IActionResult> OnGetAsync(int? id, int? assId, int? cId)
        {
            if (id == null || _context.Submissions == null)
            {
                return NotFound();
            }

            // Validate submission and assignment using passed in submission/assignment ids
            var submission =  await _context.Submissions.Include(s => s.User).Include(s => s.Assignment).FirstOrDefaultAsync(s => s.SubmissionID == id);
            if (submission == null)
            {
                return NotFound();
            }
            // Store submission and assignment once validated
            Submission = submission;

            //ViewData["AssignmentID"] = new SelectList(_context.Assignments, "AssignmentID", "Description");
            //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email");

            // store ids for navigation
            ViewData["id"] = submission.SubmissionID;
            ViewData["assId"] = assId;
            ViewData["cId"] = cId;

            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public int Score { get; set; }
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, int? assId, int? cId, int score)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Submission).State = EntityState.Modified;

            var submission = await _context.Submissions.FirstOrDefaultAsync(m => m.SubmissionID == id);
            var assignment = await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentID == assId);

            try
            {
                submission.Score = score;
                await _context.SaveChangesAsync();

                // send notification to student
                var newNotification = new Notification
                {
                    Event = NotificationEvent.AssignmentGraded,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    StudentID = submission.UserID,
                    Student = submission.User,
                    AssignmentID = assignment.AssignmentID,
                    Assignment = assignment
                };

                _context.Notifications.Add(newNotification);
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

            return RedirectToPage("./Submissions", new { id = assId, cId = cId });
        }

        private bool SubmissionExists(int id)
        {
          return (_context.Submissions?.Any(e => e.SubmissionID == id)).GetValueOrDefault();
        }

        // Method for downloading files
        public IActionResult OnGetDownload(string filename)
        {
            // Get the path to the file within the wwwroot folder
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", filename);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            //Read the File data into Byte Array.  
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            //Send the File to Download.  
            return File(bytes, "application/octet-stream", filename);
        }
    }
}
