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
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.PointsToAnalysis;

namespace LMSV1.Pages.Courses.Assignments
{
    public class AssignmentHomeModel : PageModel 
    {

        //Testing this method for the text submission
        [BindProperty]
        public string TextMessage { get; set; }     

        public class MessageController : Controller
        {

            [HttpPost]
            public ActionResult SendMessage(AssignmentHomeModel viewModel)
            {
                var message = viewModel.TextMessage;
                return View(message);
            }
        }
        //End of test code



        //References used to get database information and the signin information
        private readonly LMSV1.Data.LMSV1Context _context;
        private readonly UserManager<User> _userManager;
        

        //This is an obsolete way to upload files but I'm trying it to see if it works 
        [Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        public string Message { get; set; }

        [Obsolete]
        public AssignmentHomeModel(LMSV1.Data.LMSV1Context context, UserManager<User> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
        {
            _context = context;
            _userManager = userManager;
            Environment = _environment;
        }
   
        public Assignment Assignments { get; set; } = default!;
        public Submission Submissions { get; set; } = default;
        //This grabs the users email to be concatenated with the filename so that the download link with work properly
        //public User FileNamePartial { get; set; } = default!;
        public string SubmissionLetterGrade { get; set; }
        public IList<Submission> SubmissionGrade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? cId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (_context.Submissions != null)
            {
                SubmissionGrade = await _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.User)
                .Where(s => s.AssignmentID == id).ToListAsync();
            }

            ViewData["assId"] = id;
            ViewData["cId"] = cId;

            //If you can make this change dynamically with a ceratin = statement it could work
            //this.Message = "Student1@gmail.comTestFile2.rtf";

            //Set the signed in user information the this variable
            // var user = await _userManager.GetUserAsync(User);


            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentID == id);
            var submission = _context.Submissions.Where(m => m.UserID == user.Id)
                .FirstOrDefault(m => m.AssignmentID == id);

            if (assignment == null)
            {
                return NotFound();
            }
            else 
            {
                Assignments = assignment;
            }
            if (submission != null)
            {
                Submissions = submission;
            }
            // added this code to be more consistent with chart, can change later
            if (user.Role == "Student")
            {
                double? scoredPoints = 0.0;
                if (submission != null)
                {
                    scoredPoints = submission.Score;
                }
                
                double? scoreRatio = (scoredPoints / assignment.MaxPoints) * 100;

                if (scoreRatio >= 90)
                {
                    SubmissionLetterGrade = "A";
                }
                if (scoreRatio >= 80 && scoreRatio <= 89.9)
                {
                    SubmissionLetterGrade = "B";
                }
                if (scoreRatio >= 70 && scoreRatio <= 79.9)
                {
                    SubmissionLetterGrade = "C";
                }
                if (scoreRatio >= 60 && scoreRatio <= 69.9)
                {
                    SubmissionLetterGrade = "D";
                }
                if (scoreRatio <= 59.9)
                {
                    SubmissionLetterGrade = "E";
                }
            }
            return Page();
        }

        public InputModel Input { get; set; }

        // Variable to store the Dropdown selection of either a Text or File submission
        // Currently not implemented in POST yet
        [BindProperty]
        public string SelectedInputType { get; set; }
        [BindProperty]
        List<IFormFile> postedFiles { get; set; }

        public class InputModel
        {
            
            [StringLength(5000)]
            [Display(Name = "Submission")]
            public string Submission { get; set; }

        }

        // Methods moved to Submit page
        //public async Task<IActionResult> OnPostUploadAsync(List<IFormFile>? postedFiles, int? id)
        //{
        //    // If dropdown list is selected for Text submission
        //    if (SelectedInputType == "text")
        //    {
        //        //TEST CODE FOR THE TEXT SUBMISSION SECTION
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var newSubmission = new Submission
        //            {
        //                AssignmentID = Assignments.AssignmentID,
        //                UserID = user.Id,
        //                TextSubmission = TextMessage,
        //                SubmissionDate = DateTime.Now,

        //            };

        //            _context.Submissions.Add(newSubmission);
        //            await _context.SaveChangesAsync();
        //        }
        //    }
        //    // If dropdown list is selected for File submission
        //    else
        //    {
        //        //Set the signed in user information the this variable
        //        var user = await _userManager.GetUserAsync(User);


        //        string wwwPath = Environment.WebRootPath;
        //        //string contentPath = Environment.ContentRootPath;

        //        string path = Path.Combine(wwwPath, "Uploads");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        List<string> uploadedFiles = new List<string>();
        //        foreach (IFormFile postedFile in postedFiles)
        //        {
        //            string fileName = Path.GetFileName(user + postedFile.FileName);
        //            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        //            {
        //                postedFile.CopyTo(stream);
        //                uploadedFiles.Add(fileName);
        //                //This sets the message to the student email + the file name
        //                //this.Message +=  FileNamePartial + postedFile.FileName;
        //            }
        //        }
        //    }
        //    return RedirectToPage("./SubmissionSuccess");    //Using this will immediately take the user back to the assignment page without a notice  (user);            
        //}
      
    }
}
