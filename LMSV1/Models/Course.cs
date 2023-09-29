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
    public required string Credits { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [Display(Name = "Location")]
    public required string Location { get; set; }

    [Required(ErrorMessage = "Meeting times is required.")]
    [Display(Name = "Meet Times")]
    public required string MeetDays { get; set; }

    [Required(ErrorMessage = "Start time is required.")]
    [Display(Name = "Start Time")]
    public required string StartTime { get; set; }

    [Required(ErrorMessage = "End time is required.")]
    [Display(Name = "End Time")]
    public required string EndTime { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }

}