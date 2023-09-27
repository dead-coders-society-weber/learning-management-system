using LMSV1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSV1.Pages
{
    public class CalendarModel : PageModel
    {
        // for future use, create a ref to the DB
        private readonly LMSV1.Data.LMSV1Context _context;

        public CalendarModel(LMSV1Context context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }

        // For future use
        //public IActionResult OnGetFindAllEvents()
        //{
            
        //}
    }
}
