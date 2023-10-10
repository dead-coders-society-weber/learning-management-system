using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Xml;

namespace LMSV1.Pages.Instructor
{
    public class CreateModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public Course Course { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedDays { get; set; } = new List<int>();

        public CreateModel(Data.LMSV1Context context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int instructorId)
        {
            if (!ModelState.IsValid || _context.Courses == null || Course == null)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            // Convert SelectedDays to DaysOfWeek enum and assign to Course.MeetDays
            Course.MeetDays = SelectedDays.Aggregate(DaysOfWeek.None, (current, day) => current | (DaysOfWeek)day);

            // add instructor to course
            Course.InstructorID = instructorId;

            // create new course
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CourseManager");
        }
    }
}
