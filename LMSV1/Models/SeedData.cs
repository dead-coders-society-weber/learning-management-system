using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;

namespace LMSV1.Models;
public static class SeedData
{
    public static void Initialize(LMSV1Context context)
    {
        // Look for any courses.
        if (context.Course.Any())
        {
            return;   // DB has been seeded
        }

        context.Course.Add(new Course
        {
            CourseID = "CS370",
            Title = "Software Development II",
            Credits = "4",
            Location = "Weber NB - 324",
            MeetDays = "T,TH",
            StartTime = "11:30 AM",
            EndTime = "12:30 PM"
        });

        context.SaveChanges();
    }

    //public static async Task InitializeAsync(LMSV1UserContext dbContext, 
    //    UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    //{
    //    // Create Roles if they don't exist
    //    if (!await roleManager.RoleExistsAsync("Instructor"))
    //    {
    //        await roleManager.CreateAsync(new IdentityRole("Instructor"));
    //    }
    //    if (!await roleManager.RoleExistsAsync("Student"))
    //    {
    //        await roleManager.CreateAsync(new IdentityRole("Student"));
    //    }

    //    // Create Instructor user
    //    var instructorUser = new User
    //    {
    //        Email = "instructor@example.com",
    //        Password = "Instructor123!",
    //        FirstName = "first",
    //        LastName = "last",
    //        Birthdate = new DateTime(),
    //        Role = "Instructor"
    //    };
    //    await userManager.CreateAsync(instructorUser, instructorUser.Password);
    //    await userManager.AddToRoleAsync(instructorUser, instructorUser.Role);

    //    // Create Student user
    //    var studentUser = new User
    //    {
    //        Email = "student@example.com",
    //        Password = "Student123!",
    //        FirstName = "first",
    //        LastName = "last",
    //        Birthdate = new DateTime(),
    //        Role = "Student"
    //    };
    //    await userManager.CreateAsync(studentUser, studentUser.Password);
    //    await userManager.AddToRoleAsync(studentUser, studentUser.Role);

    //    // Seed Courses
    //    if (!dbContext.Course.Any())
    //    {
    //        dbContext.Course.Add(new Course
    //        {
    //            CourseID = "CS370",
    //            Title = "Software Development II",
    //            Credits = "4",
    //            Location = "Weber NB - 324",
    //            MeetDays = "T,TH",
    //            StartTime = "11:30 AM",
    //            EndTime = "12:30 PM"
    //        });

    //        await dbContext.SaveChangesAsync();
    //    }
    //}
}
