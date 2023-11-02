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
        public DbSet<PaymentInformation> PaymentInformation { get; set; } = default!;
        public object Assignment { get; internal set; }

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
                        SecurityStamp = Guid.NewGuid().ToString()
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
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                users[0].PasswordHash = passwordHasher.HashPassword(users[0], password);
                users[1].PasswordHash = passwordHasher.HashPassword(users[1], password);

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
                    }
                );
            });
            
            builder.Entity<Assignment>(b =>
            {
                b.ToTable("Assignment");

                // seed assignments
                b.HasData(
                    new Assignment
                    {
                        AssignmentID = 1,
                        Title = "File Upload Assignment",
                        Description = "Upload a File for this Assignment",
                        MaxPoints = 100,
                        DueDate = new DateTime(2023, 11, 03, 23, 59, 59),
                        SubmissionType = SubmissionType.FileUpload,
                        CourseID = 3750
                    },
                    new Assignment
                    {
                        AssignmentID = 2,
                        Title = "Text Entry Assignment",
                        Description = "Enter Text for this Assignment",
                        MaxPoints = 75,
                        DueDate = new DateTime(2023, 11, 05, 23, 59, 59),
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
                    new Submission
                    {
                        SubmissionID = 1,
                        AssignmentID = 2,
                        UserID = 2,
                        TextSubmission = "Here is some text.",
                        Score = null,
                        SubmissionDate = DateTime.Now
                    },
                    new Submission
                    {
                        SubmissionID = 2,
                        AssignmentID = 1,
                        UserID = 2,
                        FileName = "2_test submission.txt",
                        Score = null,
                        SubmissionDate = DateTime.Now
                    }
                );
            });

            // customize table names
            builder.Entity<PaymentInformation>().ToTable("PaymentInformation");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        }
    }
}
