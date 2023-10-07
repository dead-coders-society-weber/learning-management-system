using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using LMSV1.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Pages.Instructor.Assignments
{
    public class DetailsModel : PageModel
    {
        //References used to get database information and the signin information
        private readonly LMSV1.Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;

        //This is an obsolete way to upload files but I'm trying it to see if it works 
        [Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        public string Message { get; set; }

        [Obsolete]
        public DetailsModel(LMSV1.Data.LMSV1Context context, UserManager<User> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
        {
            _context = context;
            _userManager = userManager;
            Environment = _environment;
        }

   
        public Assignment Assignment { get; set; } = default!; 

       public async Task<IActionResult> OnGetAsync(int? id)
        {
            //Set the signed in user information the this variable
            var user = await _userManager.GetUserAsync(User);

            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignment == null)
            {
                return NotFound();
            }
            else 
            {
                Assignment = assignment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> postedFiles, int? id)
        {
            //Set the signed in user information the this variable
            var user = await _userManager.GetUserAsync(User);

            string wwwPath = Environment.WebRootPath;
            string contentPath = Environment.ContentRootPath;

            string path = Path.Combine(Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(user + postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    this.Message +=  fileName;
                }
            }
            return RedirectToPage(user);            
        }  
    }
}
