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

public enum Role
{
    Instructor, Student
}

public class Enrollment
{
    [Required]
    [Display(Name = "Enrollment ID")]
    public int EnrollmentID { get; set; }   // Primary key
    
    [Display(Name = "Grade")]
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }

    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }

    [Display(Name = "Role")]
    public Role Role { get; set; }

    [Display(Name = "Course ID")]
    public required int CourseID { get; set; }  // Foreign key
    public Course Course { get; set; }

    [Display(Name = "User ID")]
    public required int UserId { get; set; }    // Foreign key
    public User User { get; set; }
}