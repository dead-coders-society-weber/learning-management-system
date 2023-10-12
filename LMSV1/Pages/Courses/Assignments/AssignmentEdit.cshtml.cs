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
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Pages.Courses.Assignments
{
    public class AssignmentEditModel : PageModel
    {
        private readonly Data.LMSV1Context _context;

        public AssignmentEditModel(Data.LMSV1Context context)
        {
            _context = context;
        }

        public Assignment Assignment { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Assignment Name is required.")]
            [StringLength(100, MinimumLength = 4, ErrorMessage = "Assignment name must be between 4 and 100 characters.")]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Description is required.")]
            [StringLength(100, MinimumLength = 5, ErrorMessage = "Assignment name must be between 5 and 100 characters.")]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Maximum points is required.")]
            [Display(Name = "Max Points")]
            public int MaxPoints { get; set; }

            [Required(ErrorMessage = "Due date is required.")]
            [Display(Name = "Due Date")]
            [DataType(DataType.DateTime)]
            public DateTime DueDate { get; set; }

            [Required(ErrorMessage = "Submission Type is required.")]
            [Display(Name = "Submission Type")]
            public SubmissionType SubmissionType { get; set; }
        }

        private async Task LoadAsync(Assignment assignment)
        {
            // populate the fields
            Input = new InputModel
            {
                Title = assignment.Title,
                Description = assignment.Description,
                MaxPoints = assignment.MaxPoints,
                DueDate = assignment.DueDate,
                SubmissionType = assignment.SubmissionType,
            };
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            Assignment =  await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (Assignment == null)
            {
                return NotFound();
            }

            await LoadAsync(Assignment);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Assignment = await _context.Assignments.FirstOrDefaultAsync(a => a.AssignmentID == id);
            if (Assignment == null)
            {
                return NotFound($"Unable to load course with ID '{id}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(Assignment);
                return Page();
            }

            // update data
            Assignment.Title = Input.Title;
            Assignment.Description = Input.Description;
            Assignment.MaxPoints = Input.MaxPoints;
            Assignment.DueDate = Input.DueDate;
            Assignment.SubmissionType = Input.SubmissionType;

            _context.Attach(Assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(Assignment.AssignmentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SuccessPage");
        }

        private bool AssignmentExists(int id)
        {
          return (_context.Assignments?.Any(e => e.AssignmentID == id)).GetValueOrDefault();
        }
    }
}
