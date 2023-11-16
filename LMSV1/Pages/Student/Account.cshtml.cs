using LMSV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe.Checkout;
using Stripe;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMSV1.Pages.Student
{
    public class AccountModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        public string SessionId { get; set; }

        [BindProperty]
        public long TuitionAmount { get; set; }

        [BindProperty]
        public IList<Course> Courses { get; set; }

        public AccountModel(Data.LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string? payment, long? amount)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                // get enrolled courses
                Courses = await _context.Enrollments.Where(e => e.StudentID == user.Id).Select(e => e.Course).ToListAsync();

                if(payment == "success" && amount is not null)
                {
                    user.TuitionAmount -= (long)amount;
                    await _context.SaveChangesAsync();
                }
                TuitionAmount = user.TuitionAmount;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long amount)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = amount * 100, // unit amount is in cents so x100 to get dollar amount
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Tuition Payment",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = $"https://localhost:7019/Student/Account?payment=success&amount={amount}",
                CancelUrl = "https://localhost:7019/Student/Account?payment=cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return new RedirectResult(session.Url);
        }
    }
}
