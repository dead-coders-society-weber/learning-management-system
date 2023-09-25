using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LMSV1.Models;

/*
 This class contains the necesssary information about each course that will be created
and submit it into the database for storage
 */
public enum Grade
{
    A, B, C, D, F
}
public class Enrollment
{
    [Required]
    [Display(Name = "Enrollment ID")]
    public int EnrollmentID { get; set; }  // Primary key

    [Display(Name = "Course ID")]
    public required int CourseID { get; set; }

    [Display(Name = "User ID")]
    public required int UserID { get; set; }

    [Display(Name = "Grade")]
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }

    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }

    //public required Course Course { get; set; }
    //public required User user { get; set; }


}