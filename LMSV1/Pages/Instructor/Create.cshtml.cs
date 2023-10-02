using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;

namespace LMSV1.Pages.Instructor
{
    public class CreateModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        public CreateModel(Data.LMSV1Context context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Courses == null || Course == null)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (!string.IsNullOrEmpty(user.Id.ToString()))
            {
                Course.InstructorID = user.Id;
            }
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
