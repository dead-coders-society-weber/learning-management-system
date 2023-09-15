using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMSV1.Models;

namespace LMSV1.Data
{
    public class LMSV1UserContext : DbContext
    {
        public LMSV1UserContext (DbContextOptions<LMSV1UserContext> options)
            : base(options)
        {
        }

        public DbSet<LMSV1.Models.User> User { get; set; } = default!;
    }
}
