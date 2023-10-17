using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMSV1.Data;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting; //used for accessing wwwroot folder
using Microsoft.AspNetCore.Http; //required for ifile and holding uploaded file
using Microsoft.EntityFrameworkCore;

namespace LMSV1.Pages.Courses.Assignments.Submissions
{
    public class CreateModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        private IWebHostEnvironment _environment; //dependency injection to access wwwroot
        public string Message { get; set; }
        public CreateModel(LMSV1.Data.LMSV1Context context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public IActionResult OnPostUpload(List<IFormFile> postedFiles)
        {
            string wwwPath = this._environment.WebRootPath; //Get root path of wwwroot folder
            string contentPath = this._environment.ContentRootPath;

            string path = Path.Combine(this._environment.WebRootPath, "Upload"); //Formatted wwwroot path.
            if(!Directory.Exists(path))//If the directory does not exist we will create it.
            {
                Directory.CreateDirectory(path); //Create directory
            }
            List<string> uploadedFiles = new List<string>();
            foreach(IFormFile postedFile in postedFiles)//traverse file collection
            {
                string fileName = Path.GetFileName(postedFile.FileName); //get file name and store in variable
                using(FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create)) //saving the file by making a file stream class to create the file in the locaiton
                {
                    postedFile.CopyTo(stream); //Copy file to stream to complete file upload proccess.
                    uploadedFiles.Add(fileName);
                    this.Message += string.Format("<b>{0}</b> uploaded. <br/>", fileName); //Message to user
                }
            }
            return Page();
        }
        public Assignment? Assignment { get; set; } = default!;
        public async Task<IActionResult> OnGetASync(int Assignmentid, int UserID)
        {
            Assignment = await _context.Assignments
           .Include(a => a.Submissions)
           .AsNoTracking()
           .FirstOrDefaultAsync(a => a.AssignmentID == Assignmentid);
            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "File Name")]
            public string? FileName { get; set; }
            [Display(Name = "Text Submission")]
            public string? TextSubmission { get; set; }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int Assignmentid, int UserID)
        {


            if (!ModelState.IsValid || _context.Submissions == null)
            {
                return Page();
            }
            var newSubmission = new Submission
            {
                AssignmentID = Assignmentid,
                UserID = UserID,
                SubmissionDate = DateTime.Now
            };
            _context.Submissions.Add(newSubmission);
            await _context.SaveChangesAsync();

            return Redirect("./SubmitSuccess");
        }
    }
}
