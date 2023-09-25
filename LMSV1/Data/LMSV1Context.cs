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
    public class LMSV1Context : IdentityDbContext<User>
    {
        public LMSV1Context (DbContextOptions<LMSV1Context> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        //public DbSet<LMSV1.Models.User> User { get; set; } = default!;
        //public DbSet<LMSV1.Models.Course> Course { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize User Table
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
            });

            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Enrollment>().ToTable("Enrollment");
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
