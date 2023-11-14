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
    public class SubmitModel : PageModel
    {
        private readonly LMSV1.Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        private IWebHostEnvironment _environment; //dependency injection to access wwwroot
        public string Message { get; set; }
        public Assignment? Assignment { get; set; }
        public User? user { get; set; }
        public SubmitModel(LMSV1.Data.LMSV1Context context, IWebHostEnvironment environment, UserManager<User> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }
        // OnGet method
        public async Task<IActionResult> OnGetAsync(int Assignmentid, int UserID)
        {
            Assignment = _context.Assignments
                .Include(a => a.Submissions)
                .AsNoTracking()
                .FirstOrDefault(a => a.AssignmentID == Assignmentid);
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
        // OnPost method
        // Has 2 separate functions depending on whether the assignment is a FileUpload or Text entry
        public async Task<IActionResult> OnPostAsync(int Assignmentid, int UserID, List<IFormFile>?postedFiles)
        {
            if (!ModelState.IsValid || _context.Submissions == null)
            {
                return Page();
            }
            SubmissionExists(Assignmentid, UserID);
            // If file submission
            if (postedFiles != null && postedFiles.Count > 0)
            {
                string wwwPath = this._environment.WebRootPath; //Get root path of wwwroot folder
                string contentPath = this._environment.ContentRootPath;

                string path = Path.Combine(this._environment.WebRootPath, "Uploads"); //Formatted wwwroot path.
                if (!Directory.Exists(path))//If the directory does not exist we will create it.
                {
                    Directory.CreateDirectory(path); //Create directory
                }

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in postedFiles) //traverse file collection
                {
                    string fileName = Path.GetFileName(postedFile.FileName); //get file name and store in variable
                    string combinedName = $"{UserID}_{fileName}"; // add user id to file name (example: userName_fileName.ext)

                    using (FileStream stream = new FileStream(Path.Combine(path, combinedName), FileMode.Create)) //saving the file by making a file stream class to create the file in the locaiton
                    {
                        postedFile.CopyTo(stream); //Copy file to stream to complete file upload proccess.
                        uploadedFiles.Add(combinedName);
                        this.Message += string.Format("<b>{0}</b> uploaded. <br/>", combinedName); //Message to user
                    }
                    var newSubmission = new Submission
                    {
                        AssignmentID = Assignmentid,
                        UserID = UserID,
                        SubmissionDate = DateTime.Now,
                        FileName = combinedName,
                    };
                    _context.Submissions.Add(newSubmission);
                }
            }
            // If Text Submission
            else
            {
                var newSubmission = new Submission
                {
                    AssignmentID = Assignmentid,
                    UserID = UserID,
                    SubmissionDate = DateTime.Now,
                    TextSubmission = Input.TextSubmission,
                };
                _context.Submissions.Add(newSubmission);
            }

            await _context.SaveChangesAsync();

            return Redirect("./SubmitSuccess");
        }
        // Submission variable setup for checking for previous entry in DB
        Submission submission = null;

        // Checks the DB for a previous assignment for the current student and removes it
        public void SubmissionExists(int Assignmentid, int UserID)
        {
            do
            {
                Submission submission = _context.Submissions
                .AsNoTracking()
                .FirstOrDefault(a => a.UserID == UserID && a.AssignmentID == Assignmentid);
                if (submission != null)
                {
                    _context.Submissions.Remove(submission);

                    _context.SaveChanges();
                }
            } while (submission != null);
        }
    }
}
