using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Data;
using LMSV1.Models;

namespace LMSV1.Pages.Instructor.Crs
{
    public class CreateModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;
        public int courseID = 0;
        public CreateModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            courseID = id;
        //ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            return Page();
        }

        [BindProperty]
        public Assignment Assignment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Assignment.CourseID = id;
            if (!ModelState.IsValid || _context.Assignments == null || Assignment == null)
            {
                return Page();
            }
            //        var errors = ModelState
            //.Where(x => x.Value.Errors.Count > 0)
            //.Select(x => new { x.Key, x.Value.Errors })
            //.ToArray();

            _context.Assignments.Add(Assignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SuccessPage");
        }
    }
}
