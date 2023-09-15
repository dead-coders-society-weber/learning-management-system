using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;

namespace LMSV1.Pages.Authentication
{
    public class WelcomeModel : PageModel
    {

        private readonly LMSV1.Data.LMSV1UserContext _context;

        public WelcomeModel(LMSV1.Data.LMSV1UserContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null || _context.User == null)
            {
                return NotFound();
            }
            var account = _context.User.Find(Id);
            if (account == null)
            {

                return NotFound();
            }
            User = account;

            return Page();
        }

        [BindProperty]
        public User? User { get; set; }


    }
}
