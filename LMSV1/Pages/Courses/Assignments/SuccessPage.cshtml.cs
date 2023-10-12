using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSV1.Pages.Instructor.Assignments
{
    public class SuccessPageModel : PageModel
    {
        public async Task<RedirectToPageResult> OnPostAsync()
        {
            return RedirectToPage("../CourseManager");
        }
    }
}
