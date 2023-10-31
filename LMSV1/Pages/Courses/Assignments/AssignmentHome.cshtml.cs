﻿using System;
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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            //If you can make this change dynamically with a ceratin = statement it could work
            //this.Message = "Student1@gmail.comTestFile2.rtf";

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
                Assignments = assignment;
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


        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile>? postedFiles, int? id)
        {
            // If dropdown list is selected for Text submission
            if (SelectedInputType == "text")
            {
                //TEST CODE FOR THE TEXT SUBMISSION SECTION
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var newSubmission = new Submission
                    {
                        AssignmentID = Assignments.AssignmentID,
                        UserID = user.Id,
                        TextSubmission = TextMessage,
                        SubmissionDate = DateTime.Now,

                    };

                    _context.Submissions.Add(newSubmission);
                    await _context.SaveChangesAsync();
                }
            }
            // If dropdown list is selected for File submission
            else
            {
                //Set the signed in user information the this variable
                var user = await _userManager.GetUserAsync(User);


                string wwwPath = Environment.WebRootPath;
                //string contentPath = Environment.ContentRootPath;

                string path = Path.Combine(wwwPath, "Uploads");
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
                        //This sets the message to the student email + the file name
                        //this.Message +=  FileNamePartial + postedFile.FileName;
                    }
                }
            }
            return RedirectToPage("./SubmissionSuccess");    //Using this will immediately take the user back to the assignment page without a notice  (user);            
        }
      
    }
}
