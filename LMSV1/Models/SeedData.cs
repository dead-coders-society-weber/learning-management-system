using Microsoft.EntityFrameworkCore;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;
using LMSV1.Models;

namespace LMSV1.Models;
public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using (var context = new LMSV1Context(
            serviceProvider.GetRequiredService<DbContextOptions<LMSV1Context>>()))
        {
            // seed Instructor user and ensure role assignment
            var instructor1 = await EnsureUser(serviceProvider, "Instructor1@gmail.com", 
                                                "Abc123!", "Instructor");
            await EnsureRole(serviceProvider, instructor1.Email, "Instructor");

            // seed Student user and ensure role assignment
            var student1 = await EnsureUser(serviceProvider, "Student1@gmail.com", 
                                             "Abc123!", "Student");
            await EnsureRole(serviceProvider, student1.Email, "Student");

            // seed Instructor user and ensure role assignment
            var instructor2 = await EnsureUser(serviceProvider, "Instructor2@gmail.com",
                                                "Abc123!", "Instructor");
            await EnsureRole(serviceProvider, instructor2.Email, "Instructor");

            // seed Student user and ensure role assignment
            var student2 = await EnsureUser(serviceProvider, "Student2@gmail.com",
                                             "Abc123!", "Student");
            await EnsureRole(serviceProvider, student2.Email, "Student");

            // seed Instructor user and ensure role assignment
            var instructor3 = await EnsureUser(serviceProvider, "Instructor3@gmail.com",
                                                "Abc123!", "Instructor");
            await EnsureRole(serviceProvider, instructor3.Email, "Instructor");

            // seed Student user and ensure role assignment
            var student3 = await EnsureUser(serviceProvider, "Student3@gmail.com",
                                             "Abc123!", "Student");
            await EnsureRole(serviceProvider, student3.Email, "Student");

            // seed db with data
            SeedDB(context, new User[] { instructor1, student1, instructor2, student2, instructor3, student3 });
        }
    }

    private static async Task<User> EnsureUser(IServiceProvider serviceProvider,
                                                 string username, string pw, string role)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        var user = await userManager.FindByNameAsync(username);
        if (user == null)
        {
            user = new User
            {
                Email = username,
                UserName = username,
                Password = pw,
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(1995, 1, 1),
                Role = role,
                // add stock img by default for profile image
                ProfileImage = "/Uploads/stock-profile-image.jpg",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            await userManager.CreateAsync(user, pw);
        }

        if (user == null)
        {
            throw new Exception("The user has bad data");
        }

        return user;
    }

    private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                  string username, string role)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

        IdentityResult IR;
        if (!await roleManager.RoleExistsAsync(role))
        {
            IR = await roleManager.CreateAsync(new IdentityRole<int>(role));
        }

        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var user = await userManager.FindByNameAsync(username);

        if (user == null)
        {
            throw new Exception("User was not found");
        }

        IR = await userManager.AddToRoleAsync(user, role);

        return IR;
    }

    public static void SeedDB(LMSV1Context context, User[] users)
    {
        // seed courses
        if (!context.Courses.Any())
        {
            var courses = new Course[]
            {
                new Course
                {
                    CourseID = 3750,
                    Title = "CS - Software Development II",
                    Credits = 4,
                    Location = "Weber NB - 324",
                    MeetDays = DaysOfWeek.Monday | DaysOfWeek.Wednesday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0)
                }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
        }

        // seed enrollments
        if(!context.Enrollments.Any()) 
        {
            var enrollments = new Enrollment[]
            {
                new Enrollment  // Instructor enrollment (course instructor)
                {
                    UserId = users[0].Id,
                    CourseID = 3750,
                    EnrollmentDate = new DateTime(),
                    Role = Role.Instructor
                },
                new Enrollment  // Student enrollment (course participant)
                {
                    UserId = users[1].Id,
                    CourseID = 3750,
                    EnrollmentDate = new DateTime(),
                    Role = Role.Student
                }
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}