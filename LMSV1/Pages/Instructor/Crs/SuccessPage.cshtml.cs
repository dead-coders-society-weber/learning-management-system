using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSV1.Pages.Instructor.Crs
{
    public class SuccessPageModel : PageModel
    {
        public async Task<RedirectToPageResult> OnPostAsync()
        {
            return RedirectToPage("../Index");
        }
    }
}
