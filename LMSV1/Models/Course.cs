using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSV1.Models;

/*
 This class contains the necesssary information about each course that will be created
and submit it into the database for storage
 */
public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Course ID is required.")]
    [Display(Name = "Course ID")]
    public int CourseID { get; set; }  // Primary key

    [Required(ErrorMessage = "Course Name is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Course name must be between 6 and 100 characters.")]
    [Display(Name = "Course Name")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Credit hours is required.")]
    [Display(Name = "Credit Hours")]
    public int Credits { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [Display(Name = "Location")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Meeting times is required.")]
    [Display(Name = "Meet Times")]
    public DaysOfWeek MeetDays { get; set; }

    [Required(ErrorMessage = "Start time is required.")]
    [Display(Name = "Start Time")]
    [DataType(DataType.Time)]
    public TimeSpan StartTime { get; set; }

    [Required(ErrorMessage = "End time is required.")]
    [Display(Name = "End Time")]
    [DataType(DataType.Time)]
    public TimeSpan EndTime { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }
    public ICollection<Assignment>? Assignments { get; set; }
}

/* For the DaysOfWeek enum, flags allow you to combine multiple days. 
 * For instance, if a course meets on Monday and Wednesday, 
 * the value stored would be Monday | Wednesday (i.e., 1 + 4 = 5).
 */
[Flags]
public enum DaysOfWeek
{
    None = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 4,
    Thursday = 8,
    Friday = 16,
    // we can extend for Saturday and Sunday if needed
}
