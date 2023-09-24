using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LMSV1.Data
{
           
    public class LMSV1UserContext : IdentityDbContext<User>
    {
        public LMSV1UserContext (DbContextOptions<LMSV1UserContext> options)
            : base(options)
        {
        }
        public DbSet<LMSV1.Models.Course> Course { get; set; } = default!;
        public DbSet<LMSV1.Models.User> User { get; set; } = default!;
        private List<User> users = new List<User>();
        private List<IdentityRole> roles = new List<IdentityRole>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);





            builder.Entity<User>(b =>
            {
                // ignore unwanted fields
                b.Ignore(u => u.AccessFailedCount);
                b.Ignore(u => u.ConcurrencyStamp);
                b.Ignore(u => u.EmailConfirmed);
                b.Ignore(u => u.LockoutEnabled);
                b.Ignore(u => u.LockoutEnd);
                b.Ignore(u => u.PhoneNumber);
                b.Ignore(u => u.PhoneNumberConfirmed);
                b.Ignore(u => u.SecurityStamp);
                b.Ignore(u => u.TwoFactorEnabled);

                // set wanted fields
                b.Property(u => u.Email).IsRequired();

                // rename table
                b.ToTable("User");

                // FOR TESTING
                // Seed one Instuctor and one Student
                seedUsers();
                b.HasData(users);
            });

            // Customize identity table names
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");

                // Seed roles
                seedRoles();
                entity.HasData(roles);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");

                // FOR TESTING
                // Seed user roles
                entity.HasData(new[] {
                    new IdentityUserRole<string> { RoleId = roles[0].Id, UserId = users[0].Id},
                    new IdentityUserRole<string> { RoleId = roles[1].Id, UserId = users[1].Id}
                });
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }

        private void seedUsers()
        {
            users.Add(new User
            {
                Email = "instructor@email.com",
                Password = "Instructor123!",
                FirstName = "first",
                LastName = "last",
                Birthdate = new DateTime(),
                Role = "Instructor"
            });

            users.Add(new User
            {
                Email = "student@email.com",
                Password = "Student123!",
                FirstName = "first",
                LastName = "last",
                Birthdate = new DateTime(),
                Role = "Student"
            });
        }

        private void seedRoles()
        {
            roles.Add(new IdentityRole
            {
                Name = "Instructor"
            });

            roles.Add(new IdentityRole
            {
                Name = "Student"
            });
        }
    }
}
