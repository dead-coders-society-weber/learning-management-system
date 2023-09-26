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
    public class LMSV1Context : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public LMSV1Context (DbContextOptions<LMSV1Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Enrollment> Enrollments { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

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
            });

            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Enrollment>().ToTable("Enrollment");
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole<int>>().ToTable("Role");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        }
    }
}
