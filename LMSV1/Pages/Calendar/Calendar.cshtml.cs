using LMSV1.Data;
using LMSV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace LMSV1.Pages.Calendar
{
    public class CalendarModel : PageModel
    {
        // create a ref to the DB
        private readonly LMSV1Context _context;
        // create a ref to the user currently logged in with the manager
        private readonly UserManager<User> _userManager;

        public CalendarModel(LMSV1Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<CalendarEvent> CourseSchedule { get; set; }
        public User CurrentStudent { get; private set; }

        // variable used to specify the start date for classes
        public DateTime startDate = new DateTime(2023, 8, 15);
        // variable used to especify the end date for classes
        public DateTime endDate = new DateTime(2023, 12, 15);

        public async Task OnGetAsync()
        {
            // Load the currently logged user and their enrollments from the DB using an ID query 
            var user = await _userManager.GetUserAsync(User);
            CurrentStudent = await _context.Users.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == user.Id);

            // Create a List of CalendarEvent objects to be passed into the Calendar
            CourseSchedule = new List<CalendarEvent>();
            CourseSchedule = GetCoursesFromDataSource(CreateCourseSchedule(CurrentStudent));
        }

        // Method will convert objects in a list into the appropriate datatype to be displayed on the calendar
        private List<CalendarEvent> GetCoursesFromDataSource(List<Course> courses)
        {
            var events = new List<CalendarEvent>();

            foreach (var course in courses)
            {
                // convert timespan to datetime format
                TimeSpan startdate = course.StartTime;
                TimeSpan enddate = course.EndTime;

                // convert MeetDays to DaysOfWeek
                List<int> days = new List<int> { };
                if (course.MeetDays.HasFlag(DaysOfWeek.M))
                {
                    days.Add(1);
                }
                if (course.MeetDays.HasFlag(DaysOfWeek.T))
                {
                    days.Add(2);
                }
                if (course.MeetDays.HasFlag(DaysOfWeek.W))
                {
                    days.Add(3);
                }
                if (course.MeetDays.HasFlag(DaysOfWeek.Th))
                {
                    days.Add(4);
                }
                if (course.MeetDays.HasFlag(DaysOfWeek.F))
                {
                    days.Add(5);
                }
                int[] array = days.ToArray();

                var CalendarEvent = new CalendarEvent
                {
                    title = course.Title,
                    StartTime = startdate,
                    EndTime = enddate,
                    StartRecur = new DateTime(2023, 08, 15),    
                    EndRecur = new DateTime(2023, 12, 16),      
                    DaysOfWeek = array,         
                };

                events.Add(CalendarEvent);
            }
            return events;
        }

        // Method will parse the user's current enrollments with the Course List to create a list of Courses
        public List<Course> CreateCourseSchedule(User user)
        {
            var enrollment = user.Enrollments.ToList();
            var course = _context.Courses.ToList();
            List<Course> courses = new List<Course>();

            for (int i = 0; i < user.Enrollments.Count; i++)
            {
                courses.Add(enrollment[i].Course);
            }
            return courses;
        }

        // Model for the CalendarEvent object 
        // To display objects on the calendar they must be a certain type 
        // Our current model does not use DateTime fields in the Course model
        public class CalendarEvent
        {
            public string title { get; set; }
            public TimeSpan StartTime { get; set; }
            public DateTime StartRecur { get; set; }
            public TimeSpan EndTime { get; set; }
            public DateTime EndRecur { get; set; }
            public int[] DaysOfWeek { get; set; }
        }
    }
}
