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

        [TestMethod]
        //One of two unit tests added from QUINN
        public void TestStudentAccountCreation() 
        {
            //Grab the initial count of the users
            int intialUserCount = Context.Users.Count();

            //Test the creation of a new student
            User newUser = new User
            {
                Id = 3,
                Email = "TestStudent@email.com",
                NormalizedEmail = "TESTSTUDENT@EMAIL.COM",
                UserName = "TestStudent@email.com",
                NormalizedUserName = "TESTSTUDENT@EMAIL.COM",
                Password = "ABC123!",
                FirstName = "Plain",
                LastName = "Jane",
                Birthdate = new DateTime(1995,5,5),
                Role = "Student",
                
                // add stock img by default for profile image
                ProfileImage = "/Uploads/stock-profile-image.jpg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //Save this information into the database
            Context.Users.Add(newUser);
            Context.SaveChanges();

            //Grab the new count for the number of users
            int finalUserCount = Context.Users.Count();

            //check if increased by 1
            if (finalUserCount == intialUserCount + 1)
            {
                // Test passes
                Console.WriteLine("test passed.");
            }
            else
            {
                // Test fails
                Console.WriteLine("test failed.");
            }
            Assert.AreEqual(intialUserCount + 1, finalUserCount);

        }

        [TestMethod]
        //Two of Two unit tests added from QUINN
        public void TestInstructorAccountCreation() 
        {
            //Grab the initial count of the users
            int intialUserCount = Context.Users.Count();

            //Test the creation of a new instructor
            User newUser = new User
            {
                Id = 4,
                Email = "TestInstructor@email.com",
                NormalizedEmail = "TESTINSTRUCTOR@EMAIL.COM",
                UserName = "TestInstructor@email.com",
                NormalizedUserName = "TESTINSTRUCTOR@EMAIL.COM",
                Password = "ABC123!",
                FirstName = "Plain",
                LastName = "Jane",
                Birthdate = new DateTime(1995, 5, 5),
                Role = "Instructor",

                // add stock img by default for profile image
                ProfileImage = "/Uploads/stock-profile-image.jpg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //Save this information into the database
            Context.Users.Add(newUser);
            Context.SaveChanges();

            //Grab the new count for the number of users
            int finalUserCount = Context.Users.Count();

            //check if increased by 1
            if (finalUserCount == intialUserCount + 1)
            {
                // Test passes
                Console.WriteLine("test passed.");
            }
            else
            {
                // Test fails
                Console.WriteLine("test failed.");
            }
            Assert.AreEqual(intialUserCount + 1, finalUserCount);
        }

    }
}
