using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMSV1.Pages.Instructor.Assignments
{
    public class SubmissionSuccessModel : PageModel
    {
        public void OnPostAsync()
        {
            //return RedirectToPage("Instructor");
            Response.Redirect("/");
        }
    }
}
