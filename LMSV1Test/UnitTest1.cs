using LMSV1.Data;
using Microsoft.EntityFrameworkCore;

namespace LSMV1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstructorCreateCourseTest()
        {

            DbContextOptions<LMSV1Context> options = new DbContextOptions<LMSV1Context>();
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder(options);
            SqlServerDbContextOptionsExtensions.UseSqlServer(builder, "Server=(localdb)\\mssqllocaldb;Database=LMSV1UserContext-7c1a1dd0-5c00-4779-9c34-4a03eea81129;Trusted_Connection=True;MultipleActiveResultSets=true", null);
            var _context = new LMSV1Context((DbContextOptions<LMSV1Context>)builder.Options);


        }
    }
}