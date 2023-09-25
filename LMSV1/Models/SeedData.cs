using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;
using LMSV1.Models;

namespace LMSV1.Models;
public static class SeedData
{
    public static void Initialize(LMSV1Context context)
    {
        // Look for any courses.
        if (context.Courses.Any())
        {
            return;   // DB has been seeded
        }

        DateTime Birthday1 = new DateTime(1995, 1, 1); // User 1 birthday seed
        var users = new User[]
        {
            new User{//UserID = 1,
            Email = "Instructor1@gmail.com",Password = "Abc123!",FirstName = "John",
            LastName = "Doe",Birthdate = Birthday1,Role = "Instructor" },
             new User{//UserID = 2,
            Email = "Student1@gmail.com",Password = "Abc123!",FirstName = "Jane",
            LastName = "Doe",Birthdate = Birthday1,Role = "Student" }
        };
        context.Users.AddRange(users);
        context.SaveChanges();

        var courses = new Course[]
        {
            new Course {CourseNumber = "CS370",Title = "Software Development II",Credits = "4",
                Location = "Weber NB - 324",MeetDays = "T,TH",StartTime = "11:30 AM",EndTime = "12:30 PM"}
        };
        context.Courses.AddRange(courses);
        context.SaveChanges();

        //DateTime enrollmentDate1 = new DateTime(2023, 9, 15); // User 1 birthday seed
        //var enrollments = new Enrollment[]
        //{
        //    new Enrollment{UserID = "1",CourseID = 0,EnrollmentDate =  enrollmentDate1 }

        //};
        //context.Enrollments.AddRange(enrollments);
        //context.SaveChanges();

    }
}