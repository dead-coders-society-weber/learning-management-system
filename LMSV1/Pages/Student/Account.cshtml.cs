using LMSV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSV1.Pages.Student
{
    public class AccountModel : PageModel
    {
       
            private readonly Data.LMSV1Context _context;

            public AccountModel(Data.LMSV1Context context)
            {
                _context = context;
            }

            public IActionResult OnGet()
            {
                return Page();
            }

            [BindProperty]
            public PaymentInformation paymentInformation { get; set; } = default!;

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid || _context.PaymentInformation == null || paymentInformation == null)
                {
                    return Page();
                }

                _context.PaymentInformation.Add(paymentInformation);
                await _context.SaveChangesAsync();
                
                return RedirectToPage("./Account");
        }
    }
}
