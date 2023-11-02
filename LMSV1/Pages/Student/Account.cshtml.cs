using LMSV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe.Checkout;
using Stripe;

namespace LMSV1.Pages.Student
{
    public class AccountModel : PageModel
    {
        private readonly Data.LMSV1Context _context;
        public string SessionId { get; set; }

        public AccountModel(Data.LMSV1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
                SuccessUrl = "https://localhost:7019/Student/Success",
                CancelUrl = "https://localhost:7019/Student/Cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return new RedirectResult(session.Url);
        }
    }
}
