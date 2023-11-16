using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace LMSV1.Data
{
    public class LMSV1Context : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public LMSV1Context (DbContextOptions<LMSV1Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Enrollment> Enrollments { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<Assignment> Assignments { get; set; } = default!;
        public DbSet<Submission> Submissions { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize User Table
            builder.Entity<User>(b =>
            {
                // ignore unwanted fields
                b.Ignore(u => u.AccessFailedCount);
                b.Ignore(u => u.EmailConfirmed);
                b.Ignore(u => u.LockoutEnabled);
                b.Ignore(u => u.LockoutEnd);
                b.Ignore(u => u.PhoneNumber);
                b.Ignore(u => u.PhoneNumberConfirmed);
                b.Ignore(u => u.TwoFactorEnabled);

                // set wanted fields
                b.Property(u => u.Email).IsRequired();

                // rename table
                b.ToTable("User");

                // add foreign key constraints
                b.HasMany(e => e.Enrollments)
                 .WithOne(e => e.Student)
                 .HasForeignKey(e => e.StudentID)
                 .OnDelete(DeleteBehavior.Restrict);
                b.HasMany(e => e.Courses)
                 .WithOne(e => e.Instructor)
                 .HasForeignKey(e => e.InstructorID);
                b.HasMany(e => e.Notifications)
                 .WithOne(e => e.Student)
                 .HasForeignKey(e => e.StudentID)
                 .OnDelete(DeleteBehavior.Restrict);

                // seed users
                string password = "Abc123!";
                var users = new User[]
                {
                    new User
                    {
                        Id = 1,
                        Email = "Instructor1@gmail.com",
                        NormalizedEmail = "INSTRUCTOR1@GMAIL.COM",
                        UserName = "Instructor1@gmail.com",
                        NormalizedUserName = "INSTRUCTOR1@GMAIL.COM",
                        Password = password,
                        FirstName = "John",
                        LastName = "Doe",
                        Birthdate = new DateTime(1995, 1, 1),
                        Role = "Instructor",
                        // add stock img by default for profile image
                        ProfileImage = "/Uploads/stock-profile-image.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        TuitionAmount = 0
                    },
                    new User
                    {
                        Id = 2,
                        Email = "Student1@gmail.com",
                        NormalizedEmail = "STUDENT1@GMAIL.COM",
                        UserName = "Student1@gmail.com",
                        NormalizedUserName = "STUDENT1@GMAIL.COM",
                        Password = password,
                        FirstName = "John",
                        LastName = "Doe",
                        Birthdate = new DateTime(1995, 1, 1),
                        Role = "Student",
                        // add stock img by default for profile image
                        ProfileImage = "/Uploads/stock-profile-image.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        TuitionAmount = 400
                    },
                    new User
                    {
                        Id = 3,
                        Email = "Instructor2@gmail.com",
                        NormalizedEmail = "INSTRUCTOR2@GMAIL.COM",
                        UserName = "Instructor2@gmail.com",
                        NormalizedUserName = "INSTRUCTOR2@GMAIL.COM",
                        Password = password,
                        FirstName = "John2",
                        LastName = "Doe",
                        Birthdate = new DateTime(1995, 1, 1),
                        Role = "Instructor",
                        // add stock img by default for profile image
                        ProfileImage = "/Uploads/stock-profile-image.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        TuitionAmount = 0
                    },
                    new User
                    {
                        Id = 4,
                        Email = "Student4@gmail.com",
                        NormalizedEmail = "STUDENT4@GMAIL.COM",
                        UserName = "Student4@gmail.com",
                        NormalizedUserName = "STUDENT4@GMAIL.COM",
                        Password = password,
                        FirstName = "Jane",
                        LastName = "Doe",
                        Birthdate = new DateTime(1995, 4, 4),
                        Role = "Student",
                        // add stock img by default for profile image
                        ProfileImage = "/Uploads/stock-profile-image.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        TuitionAmount = 400
                    },
                    new User
                    {
                        Id = 5,
                        Email = "Student5@gmail.com",
                        NormalizedEmail = "STUDENT5@GMAIL.COM",
                        UserName = "Student5@gmail.com",
                        NormalizedUserName = "STUDENT5@GMAIL.COM",
                        Password = password,
                        FirstName = "Johnathan",
                        LastName = "Doe",
                        Birthdate = new DateTime(1995, 5, 5),
                        Role = "Student",
                        // add stock img by default for profile image
                        ProfileImage = "/Uploads/stock-profile-image.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        TuitionAmount = 400
                    }
                };

                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                users[0].PasswordHash = passwordHasher.HashPassword(users[0], password);
                users[1].PasswordHash = passwordHasher.HashPassword(users[1], password);
                users[2].PasswordHash = passwordHasher.HashPassword(users[2], password);
                users[3].PasswordHash = passwordHasher.HashPassword(users[3], password);
                users[4].PasswordHash = passwordHasher.HashPassword(users[4], password);

                b.HasData(users);
            });

            // Customize Role table
            builder.Entity<IdentityRole<int>>(b =>
            {
                b.ToTable("Role");

                // seed roles
                b.HasData(
                    new IdentityRole<int>
                    {
                        Id = 1,
                        Name = "Instructor",
                        NormalizedName = "INSTRUCTOR"
                    },
                    new IdentityRole<int>
                    {
                        Id = 2,
                        Name = "Student",
                        NormalizedName = "STUDENT"
                    }
                );
            });

            // Customize UserRole table
            builder.Entity<IdentityUserRole<int>>(b =>
            {
                b.ToTable("UserRoles");

                // seed user roles
                b.HasData(
                    new IdentityUserRole<int>
                    {
                        RoleId = 1,
                        UserId = 1,
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 2,
                        RoleId = 2,
                    },
                    new IdentityUserRole<int>
                    {
                        RoleId = 1,
                        UserId = 3,
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 4,
                        RoleId = 2,
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 5,
                        RoleId = 2,
                    }
                );
            });

            builder.Entity<Department>(b =>
            {
                b.ToTable("Department");

                // add foreign key constraints
                b.HasMany(d => d.Courses)
                 .WithOne(d => d.Department)
                 .HasForeignKey(d => d.DepartmentID);

                // seed departments
                b.HasData(
                    new Department
                    {
                        DepartmentID = "CS",
                        Name = "Computer Science"
                    },
                    new Department
                    {
                        DepartmentID = "MATH",
                        Name = "Mathematics"
                    },
                    new Department
                    {
                        DepartmentID = "HIST",
                        Name = "History"
                    },
                    new Department
                    {
                        DepartmentID = "ENGL",
                        Name = "English"
                    },
                    new Department
                    {
                        DepartmentID = "ART",
                        Name = "Art"
                    }
                );
            });

            builder.Entity<Course>(b =>
            {
                b.ToTable("Course");

                // add foreign key constraints
                b.HasMany(e => e.Enrollments)
                 .WithOne(e => e.Course)
                 .HasForeignKey(e => e.CourseID);

                // seed courses
                b.HasData(
                    new Course
                    {
                        CourseID = 3750,
                        Title = "Software Development II",
                        Credits = 4,
                        Location = "Weber NB - 324",
                        MeetDays = DaysOfWeek.M | DaysOfWeek.W,
                        StartTime = new TimeSpan(9, 0, 0),
                        EndTime = new TimeSpan(11, 0, 0),
                        DepartmentID = "CS",
                        InstructorID = 1
                    },
                    new Course
                    {
                        CourseID = 4801,
                        Title = "Advanced Algorithms",
                        Credits = 3,
                        Location = "Tech Hall - 101",
                        MeetDays = DaysOfWeek.T | DaysOfWeek.Th,
                        StartTime = new TimeSpan(14, 0, 0),
                        EndTime = new TimeSpan(15, 30, 0),
                        DepartmentID = "CS",
                        InstructorID = 3
                    },
                    new Course
                    {
                        CourseID = 5302,
                        Title = "Linear Algebra",
                        Credits = 4,
                        Location = "Math Building - 205",
                        MeetDays = DaysOfWeek.M | DaysOfWeek.W | DaysOfWeek.F,
                        StartTime = new TimeSpan(10, 0, 0),
                        EndTime = new TimeSpan(11, 15, 0),
                        DepartmentID = "MATH",
                        InstructorID = 1
                    },
                    new Course
                    {
                        CourseID = 3775,
                        Title = "Modern World History",
                        Credits = 3,
                        Location = "History Hall - 330",
                        MeetDays = DaysOfWeek.T | DaysOfWeek.Th,
                        StartTime = new TimeSpan(13, 0, 0),
                        EndTime = new TimeSpan(14, 30, 0),
                        DepartmentID = "HIST",
                        InstructorID = 1
                    },
                    new Course
                    {
                        CourseID = 4020,
                        Title = "Shakespearean Literature",
                        Credits = 3,
                        Location = "Literature Dept - 210",
                        MeetDays = DaysOfWeek.W | DaysOfWeek.F,
                        StartTime = new TimeSpan(9, 30, 0),
                        EndTime = new TimeSpan(11, 0, 0),
                        DepartmentID = "ENGL",
                        InstructorID = 3
                    },
                    new Course
                    {
                        CourseID = 4550,
                        Title = "Contemporary Art Practices",
                        Credits = 4,
                        Location = "Art Studio - 120",
                        MeetDays = DaysOfWeek.M | DaysOfWeek.Th,
                        StartTime = new TimeSpan(15, 0, 0),
                        EndTime = new TimeSpan(17, 0, 0),
                        DepartmentID = "ART",
                        InstructorID = 3
                    }
                );
            });

            builder.Entity<Enrollment>(b =>
            {
                b.ToTable("Enrollment");

                // seed enrollments
                b.HasData(
                    new Enrollment  // Student enrollment (course participant)
                    {
                        EnrollmentID = 1,
                        StudentID = 2,
                        CourseID = 3750,
                        EnrollmentDate = DateTime.Now,
                        Grade = "A+",
                        GradePercentage = 100,
                        PointsEarned = 400
                    },
                    new Enrollment  // Student enrollment (course participant)
                    {
                        EnrollmentID = 2,
                        StudentID = 4,
                        CourseID = 3750,
                        EnrollmentDate = DateTime.Now,
                        Grade = "C+",
                        GradePercentage = 78.8,
                        PointsEarned = 315
                    },
                    new Enrollment  // Student enrollment (course participant)
                    {
                        EnrollmentID = 3,
                        StudentID = 5,
                        CourseID = 3750,
                        EnrollmentDate = DateTime.Now,
                        Grade = "E",
                        GradePercentage = 18.8,
                        PointsEarned = 75
                    }
                );
            });
            
            builder.Entity<Assignment>(b =>
            {
                b.ToTable("Assignment");

                // add foreign key constraints
                b.HasMany(e => e.Notifications)
                 .WithOne(e => e.Assignment)
                 .HasForeignKey(e => e.AssignmentID);

                // seed assignments
                b.HasData(
                    // Assignment for File upload
                    new Assignment 
                    {
                        AssignmentID = 1,
                        Title = "File Assignment 1",
                        Description = "This is a File Upload assignment test that is turned in and graded.",
                        MaxPoints = 100,
                        DueDate = new DateTime(2023, 11, 03, 23, 59, 59),
                        SubmissionType = SubmissionType.FileUpload,
                        CourseID = 3750
                    },
                    new Assignment
                    {
                        AssignmentID = 3,
                        Title = "File Assignment 2",
                        Description = "This is an assignment that is past due, but one student has no submission.",
                        MaxPoints = 100,
                        DueDate = new DateTime(2023, 11, 08, 23, 59, 59),
                        SubmissionType = SubmissionType.FileUpload,
                        CourseID = 3750
                    },
                    new Assignment
                    {
                        AssignmentID = 5,
                        Title = "File Assignment 3",
                        Description = "This is an assignment that needs a File Upload and is not yet due.",
                        MaxPoints = 200,
                        DueDate = new DateTime(2023, 11, 17, 23, 59, 59),
                        SubmissionType = SubmissionType.FileUpload,
                        CourseID = 3750
                    },
                    // Assignment for Text entry
                    new Assignment
                    {
                        AssignmentID = 2,
                        Title = "Text Assignment 1",
                        Description = "This is a Text entry assignment test that is turned in and graded.",
                        MaxPoints = 100,
                        DueDate = new DateTime(2023, 11, 05, 23, 59, 59),
                        SubmissionType = SubmissionType.TextEntry,
                        CourseID = 3750
                    },
                    new Assignment
                    {
                        AssignmentID = 4,
                        Title = "Text Assignment 2",
                        Description = "This is an assignment that is past due, but one student has no submission.",
                        MaxPoints = 100,
                        DueDate = new DateTime(2023, 11, 08, 23, 59, 59),
                        SubmissionType = SubmissionType.TextEntry,
                        CourseID = 3750
                    },
                    new Assignment
                    {
                        AssignmentID = 6,
                        Title = "Text Assignment 3",
                        Description = "This is an assignment that needs a Text entry and is not yet due.",
                        MaxPoints = 150,
                        DueDate = new DateTime(2023, 11, 29, 23, 59, 59),
                        SubmissionType = SubmissionType.TextEntry,
                        CourseID = 3750
                    }
                );
            });

            builder.Entity<Submission>(b =>
            {
                b.ToTable("Submission");

                // seed submissions
                b.HasData(
                    // File submission for File upload assignment
                    new Submission
                    {
                        SubmissionID = 1,
                        AssignmentID = 1,
                        UserID = 2,
                        FileName = "2_test submission.txt",
                        Score = 100,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 2,
                        AssignmentID = 1,
                        UserID = 4,
                        FileName = "4_test submission.txt",
                        Score = 75,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 3,
                        AssignmentID = 1,
                        UserID = 5,
                        FileName = "5_test submission.txt",
                        Score = 25,
                        SubmissionDate = DateTime.Now
                    }, 
                    new Submission
                    {
                        SubmissionID = 4,
                        AssignmentID = 3,
                        UserID = 2,
                        FileName = "2_test submission2.txt",
                        Score = 100,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 5,
                        AssignmentID = 3,
                        UserID = 4,
                        FileName = "4_test submission2.txt",
                        Score = 75,
                        SubmissionDate = DateTime.Now
                    },
                    // Text submission for Text entry assignment
                    new Submission
                    {
                        SubmissionID = 6,
                        AssignmentID = 2,
                        UserID = 2,
                        TextSubmission = "Here is some text.",
                        Score = 100,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 7,
                        AssignmentID = 2,
                        UserID = 4,
                        TextSubmission = "Here is some text.",
                        Score = 90,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 8,
                        AssignmentID = 2,
                        UserID = 5,
                        TextSubmission = "Here is some text.",
                        Score = 50,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 9,
                        AssignmentID = 4,
                        UserID = 2,
                        TextSubmission = "Here is some text.",
                        Score = 100,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 10,
                        AssignmentID = 4,
                        UserID = 4,
                        TextSubmission = "Here is some text.",
                        Score = 75,
                        SubmissionDate = DateTime.Now
                    }
                );
            });

            // customize table names
            builder.Entity<Notification>().ToTable("Notification");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        }
    }
}
