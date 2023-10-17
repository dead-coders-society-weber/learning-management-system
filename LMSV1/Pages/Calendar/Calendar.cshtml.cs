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

        public List<Course> courses { get; set; }
        public List<CalendarCourseEvent> CourseSchedule { get; set; }
        public List<CalendarAssignmentEvent> AssignmentSchedule { get; set; }
        public User CurrentStudent { get; private set; }

        // variable used to specify the start date for classes
        public DateTime startDate = new DateTime(2023, 8, 15);
        // variable used to especify the end date for classes
        public DateTime endDate = new DateTime(2023, 12, 16);

        public async Task OnGetAsync()
        {
            // Load the currently logged user and their enrollments from the DB using an ID query 
            var user = await _userManager.GetUserAsync(User);
            CurrentStudent = await _context.Users.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == user.Id);

            // Create a List of CalendarEvent objects to be passed into the Calendar
            CourseSchedule = new List<CalendarCourseEvent>();
            AssignmentSchedule = new List<CalendarAssignmentEvent>();
            // Create a List of Courses to be used for Course and Assignment schedule
            courses = new List<Course>();
            // Generate courses the student is enrolled them and add to StudentSchedule
            CreateCourseSchedule(CurrentStudent);
            GetCoursesFromDataSource();
            // Generate assignments for the courses the student is enrolled in.
            GetAssignmentsFromDataSource(CreateAssignmentSchedule());
        }

        // Method will convert objects in a list into the appropriate datatype to be displayed on the calendar
        private void GetCoursesFromDataSource()
        {
            // iterate through course list:
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

                // Create CalendarEvent object
                var CalendarEvent = new CalendarCourseEvent
                {
                    title = course.Title,
                    StartTime = startdate,
                    EndTime = enddate,
                    StartRecur = startDate,
                    EndRecur = endDate,
                    DaysOfWeek = array,
                    Color = "#3c486b",
                };

                CourseSchedule.Add(CalendarEvent);
            }
        }

        // Method will parse the user's current enrollments with the Course List to create a list of Courses
        public void CreateCourseSchedule(User user)
        {
            var enrollment = user.Enrollments.ToList();
            var course = _context.Courses.ToList();

            for (int i = 0; i < enrollment.Count; i++)
            {
                for (int j = 0; j < course.Count; j++)
                {
                    if (enrollment[i].CourseID == course[j].CourseID)
                    {
                        courses.Add(course[j]);
                    }
                }
            }
        }

        // Method will convert assignment objects into CalendarEvent objects for the student's currently enrolled courses
        public void GetAssignmentsFromDataSource(List<Assignment> assignments)
        {
            foreach (var assignment in assignments)
            {
                var CalenderEvent = new CalendarAssignmentEvent
                {
                    title = assignment.Title,
                    Start = assignment.DueDate,
                    End = assignment.DueDate,
                    Color = "purple",
                };

                AssignmentSchedule.Add(CalenderEvent);
            }


        }

        // Method will parse the user's current courses with assignments list to create a list of assignments that are due
        public List<Assignment> CreateAssignmentSchedule()
        {
            var assignment = _context.Assignments.ToList();
            List<Assignment> assignments = new List<Assignment>();

            for (int i = 0; i < courses.Count; i++)
            {
                for (int j = 0; j < assignment.Count; j++)
                {
                    if (courses[i].CourseID == assignment[j].CourseID)
                    {
                        assignments.Add(assignment[j]);
                    }
                }
            }
            return assignments;
        }

        // Model for the CalendarEvent object 
        // To display objects on the calendar they must be a certain type 
        // Our current model does not use DateTime fields in the Course model
        public class CalendarCourseEvent
        {
            public string title { get; set; }
            public TimeSpan StartTime { get; set; }
            public DateTime StartRecur { get; set; }
            public TimeSpan EndTime { get; set; }
            public DateTime EndRecur { get; set; }
            public int[] DaysOfWeek { get; set; }
            public string Color { get; set; }
        }
        // Model for CalendarAssignmentEvent object
        // Since assignments are not recurring,
        // They require a new model due to conflicting parameters
        public class CalendarAssignmentEvent
        {
            public string title { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string EventType = "assignment";
            public string Color { get; set; }
        }
    }
}
