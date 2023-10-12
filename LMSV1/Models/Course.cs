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

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100)]
    [Display(Name = "Title")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Credit hours is required.")]
    [Display(Name = "Credit Hours")]
    [Range(0, 5)]
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

    [Required(ErrorMessage = "Department is required")]
    [Display(Name = "Department")]
    public string DepartmentID { get; set; } // Foreign key
    public Department Department { get; set; }

    [Required(ErrorMessage = "Instructor is required")]
    [Display(Name = "Instructor")]
    public int InstructorID { get; set; } // Foreign key
    public User Instructor { get; set; }

    // For display purposes
    [Display(Name = "Course Name")]
    public string CourseName { get { return DepartmentID + " " + CourseID; } }

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
    M = 1,
    T = 2,
    W = 4,
    Th = 8,
    F = 16,
    // we can extend for Saturday and Sunday if needed
}
