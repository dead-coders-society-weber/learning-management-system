using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LMSV1.Models;

/*
 This class contains the necesssary information about each course that will be created
and submit it into the database for storage
 */
// Changed grade field to a string to reflect the grading criteria outlined in the class syllabus
//public enum Grade
//{
//    A, B, C, D, F
//}

public class Enrollment
{
    [Required]
    [Display(Name = "Enrollment ID")]
    public int EnrollmentID { get; set; }   // Primary key
    
    [Display(Name = "Grade")]
    [DisplayFormat(NullDisplayText = "No grade")]
    public string? Grade { get; set; }

    [Display(Name = "Grade Percentage")]
    public double? GradePercentage { get; set; }

    [Display(Name = "Points Earned")]
    public double? PointsEarned { get; set; }

    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }

    [Display(Name = "Course ID")]
    public required int CourseID { get; set; }  // Foreign key
    public Course Course { get; set; }

    [Display(Name = "User ID")]
    public required int StudentID { get; set; }    // Foreign key
    public User Student { get; set; }
}