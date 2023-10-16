using LMSV1.Data;
using LMSV1.Models;
using LMSV1.Pages;
using LMSV1.Pages.Courses.Student;
using LMSV1.Pages.Student;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Drawing.Text;
using System.Security;

namespace LSMV1Test 
{
    [TestClass]
    public class UnitTest1 
    {
        private static DbContextOptions<LMSV1Context> options = new DbContextOptionsBuilder<LMSV1Context>().UseInMemoryDatabase(databaseName: "mockDB").Options;
        private readonly LMSV1Context Context = new LMSV1Context(options);


        [TestMethod]
        public void TestInit()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

        }
        [TestMethod]
        public void InstructorCanCreateACourseTest()
        {

            //Seed();
            int intialCourseCount = Context.Courses.Count();
   

            int instructorID = 1;
            Course newCourse = new Course
            {
                CourseID = 3353,
                Title = "Test Class 3",
                Credits = 3,
                Location = "Weber NB - 324",
                MeetDays = DaysOfWeek.T | DaysOfWeek.Th,
                StartTime = new TimeSpan(7, 0, 0),
                EndTime = new TimeSpan(9, 0, 0),
                DepartmentID = "CS",
                InstructorID = instructorID
            };
            Context.Courses.Add(newCourse);
            Context.SaveChanges();


            //assert
            int finalCourseCount = Context.Courses.Count();

            //check if increased by 1
            if (finalCourseCount == intialCourseCount + 1)
            {
                // Test passes
                Console.WriteLine("test passed.");
            }
            else
            {
                // Test fails
                Console.WriteLine("test failed.");
            }
            Assert.AreEqual(intialCourseCount + 1, finalCourseCount);


        }
        [TestMethod]
        public async Task StudentCanRegisterForClassAsync()
        {

            //int CurUser = User.CountAsync();
            int initialEnrollmentCount = Context.Enrollments.Count();

            int studentId = 2;// studentId;
            //int courseId = courseId;
            int courseId = 1234;

            // Act: Call the registration method
            var courseRegistrationModel = new CourseRegistrationModel(Context, null); // Assuming UserManager is not needed for this test
            await courseRegistrationModel.OnPostRegisterAsync(studentId, courseId);


            int finalEnrollmentCount = Context.Enrollments.Count();
            //check if increased by 1
            if (finalEnrollmentCount == initialEnrollmentCount + 1)
            {
                // Test passes
                Console.WriteLine("test passed.");
            }
            else
            {
                // Test fails
                Console.WriteLine("test failed.");
            }
            Assert.AreEqual(initialEnrollmentCount + 1, finalEnrollmentCount);
        }
    }
}
