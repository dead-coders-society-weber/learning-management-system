using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net;

namespace LMSV1.Pages
{
    public class FilePageModel : PageModel
    {
        //Microsoft.Asp.....Provides types that allow us to start certain web applications
        //IWebHostEnvironment provides information about the web hosting environment an application is running in.
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment;

        //Created for our message upon successful upload and used for the download as well
        public string Message { get; set; }

        //Creation of our environment for navigation purposes
        public FilePageModel(Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        //This method handles what happens when the upload occurs
        //postedFiles is used to find our file when looking to upload
        public void OnPostUpload(List<IFormFile> postedFiles)
        {
            //Allows webfiles to be search for
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            //Combining two strings in a path here. A WebRootPath and Uploads
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");

            //Search to see if a directory exists and then pass in the path parameter just created
            if (!Directory.Exists(path))
            {
                //If not create a directory
                Directory.CreateDirectory(path);
            }

            //List creates a list of objects that can be accessed via an index
            List<string> uploadedFiles = new List<string>();

            //foreach is used to loop through elements in an array. IFormFile represents a file sent with an http request
            foreach (IFormFile postedFile in postedFiles)
            {


                //Assign our retrieved file to a variable fileName with Path.GetFileName(postedFile.FileName)
                string fileName = Path.GetFileName(postedFile.FileName);


                //This will take the path from the original system its pulling from and the filename then create
                //a file inside wwwroot/Uploads that is the same name as the original file.
                //Then this.message will store that original file name to be used in the FilePage.cshtml area for download 
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    this.Message += string.Format("{0}", fileName);
                }
            }

        }
    }
}

