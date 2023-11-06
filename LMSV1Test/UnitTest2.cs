using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSV1.Data;
using LMSV1.Models;
using LMSV1.Pages.Courses.Assignments.Submissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using SQLitePCL;

//namespace LMSV1.Pages.Courses.Assignments.Submissions
namespace LMSV1Test
{
    [TestClass]
    public class UnitTest2
    {
        private static DbContextOptions<LMSV1Context> options = new DbContextOptionsBuilder<LMSV1Context>().UseInMemoryDatabase(databaseName: "mockDB").Options;
        private readonly LMSV1Context Context = new LMSV1Context(options);

        [TestMethod]
        public void Student_Submit_Assignment_File_Test()
        {
            //Using seed data for this test
            //Using InstructorID 1,student ID: 2, Assignment ID: 1
            //File upload does not upload yet. Only the database is filled.
            Console.WriteLine("Test to check if a student can submit an assignment file.");
            int intialSubmissionCount = Context.Submissions.Count();

            Submission newSubmission = new Submission
            {
                SubmissionID = 5,
                AssignmentID = 2,
                UserID = 2, //Student ID: 2
                FileName = "2_Test.txt", //{UserID}_{fileName}"
                Score = null,
                SubmissionDate = DateTime.Now
            };
            Context.Submissions.Add(newSubmission);
            Context.SaveChanges();
            int finalSubmissionCount = Context.Courses.Count();
            if (finalSubmissionCount == intialSubmissionCount + 1)
                Console.WriteLine("Test passed.");
            else
                Console.WriteLine("Test failed.");
        }

        [TestMethod]
        public async Task Instructor_Grade_Assignment_File_Test()
        {
            // Create user file submission
            Submission newSubmission = new Submission
            {
                SubmissionID = 4,
                AssignmentID = 2,
                UserID = 2,
                FileName = "2_assignment3.txt",
                Score = null,
                SubmissionDate = DateTime.Now
            };

            // Add submission to DB
            Context.Submissions.Add(newSubmission);
            Context.SaveChanges();

            // Set submission id
            int submissionId = 4;

            // Create page model with context
            var editModel = new EditModel(Context);

            // Simulate grading from instrucotr
            int score = 80;
            await editModel.OnPostAsync(submissionId, 2, 1, score);

            // check if grade is updated
            var submission = Context.Submissions.FindAsync(submissionId).Result;
            if (submission != null)
            {
                Console.WriteLine("Test Passed.");
            }
            else
            {
                Console.WriteLine("Test Failed.");
            }

            // Run unit test
            Assert.AreEqual(80, submission.Score);
        }
    }
}
