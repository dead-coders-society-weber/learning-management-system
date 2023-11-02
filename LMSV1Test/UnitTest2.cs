using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSV1.Data;
using LMSV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using SQLitePCL;

/*
 * Making the test where student can submit a file upload assignment.
 * Teacher can grade the file upload assignment
 *  /
 */

namespace LMSV1.Pages.Courses.Assignments.Submissions
//namespace LMSV1Test
{
    [TestClass]
    internal class UnitTest2
    {
        private static DbContextOptions<LMSV1Context> options = new DbContextOptionsBuilder<LMSV1Context>().UseInMemoryDatabase(databaseName: "mockDB").Options;
        private readonly LMSV1Context Context = new LMSV1Context(options);

        [TestMethod]
        public void Student_Submit_Assignment_File_Test()
        {
            //Using seed data for this test
            //Using InstructorID 1
            //Use student ID: 2
            //Use Assignment ID: 1
            //File upload does not upload yet. Only the database is filled.
            Console.WriteLine("Test to check if a student can submit an assignment file.");
            int intialSubmissionCount = Context.Submissions.Count();

            Submission newSubmission = new Submission
            {
                AssignmentID = '1',
                UserID = 2, //Student ID: 2
                SubmissionDate = DateTime.Now,
                FileName = "2_Test.txt", //{UserID}_{fileName}"
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
        public void Instructor_Grade_Assignment_File_Test()
        {

        }
    }
}
