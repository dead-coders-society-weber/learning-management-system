using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;

    public class LMSV1CourseContext : DbContext
    {
        public LMSV1CourseContext (DbContextOptions<LMSV1CourseContext> options)
            : base(options)
        {
        }

        public DbSet<LMSV1.Models.Course> Course { get; set; } = default!;
    }
