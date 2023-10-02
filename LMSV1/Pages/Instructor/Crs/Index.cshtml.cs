using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;

namespace LMSV1.Pages.Instructor.Crs
{
    public class IndexModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;

        public IndexModel(LMSV1.Data.LMSV1Context context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Assignments != null)
            {
                Assignment = await _context.Assignments
                .Include(a => a.Course).ToListAsync();
            }
        }
    }
}
