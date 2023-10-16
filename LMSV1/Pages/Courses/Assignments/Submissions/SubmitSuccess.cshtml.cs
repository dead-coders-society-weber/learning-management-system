using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMSV1.Pages.Courses.Assignments
{
    public class SubmissionSuccessModel : PageModel
    {
        public void OnPostAsync()
        {
            //Sends you back to the dashboard
            Response.Redirect("/");
        }
    }
}
