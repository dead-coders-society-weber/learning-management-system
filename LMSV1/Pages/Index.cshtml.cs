using LMSV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMSV1.Pages
{
    public class IndexModel : PageModel
    {
        //Created to reference the database
        private readonly LMSV1.Data.LMSV1Context _context;

        //Allows us to look at the database and reference information inside of it
        public IndexModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        //A list created of the course information, considering that there are multiple courses
        //we need to use the IList<Course> way of referencing so that we can use an array
        public IList<Course> Course { get; set; } = default!;

        //This method will get the information from the database
        //Because it is an Async method it will not wait for the data to be gathered before allowing
        //the user to continue with operations, this helps with optimization.
        public async Task<IActionResult> OnGetAsync()
        {
            //If the course exists then grab it and assign it to Course
            if (_context.Courses != null)
            {
                Course = await _context.Courses.ToListAsync();
            }

            return Page();
        }
    }
}