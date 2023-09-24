//using Microsoft.EntityFrameworkCore;
//using LMSV1.Data;

//namespace LMSV1.Models;
//public static class SeedData
//{
//    public static void Initialize(IServiceProvider serviceProvider)
//    {
//        using (var context = new LMSV1UserContext(
//            serviceProvider.GetRequiredService<
//                DbContextOptions<LMSV1UserContext>>()))
//        {
//            if (context == null || context.Course == null)
//            {
//                throw new ArgumentNullException("Null Context");
//            }

//            // Look for any Courses.
//            if (context.Course.Any())
//            {
//                return;   // DB has been seeded
//            }

//            context.Course.AddRange(
//                new Course
//                {
//                    CourseID = "CS370",
//                    Title = "Software Development II",
//                    Credits = "4",
//                    Location = "Weber NB - 324",
//                    MeetDays = "T,TH",
//                    StartTime = "11:30 AM",
//                    EndTime = "12:30 PM"
//                });
//            context.SaveChanges();
//        }
//    }
//}
