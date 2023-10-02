using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSV1.Models;

/*
 This class holds the assignment information for each course. 
 The Assignment database model.
 */
public class Assignment
{

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Assignment ID is required.")]
    [Display(Name = "Assignment ID")]
    public int AssignmentID { get; set; }  // Primary key

    [Required(ErrorMessage = "Course ID is required.")]
    [Display(Name = "Course ID")]
    public int CourseID { get; set; }  // Foreign Key

    [Required(ErrorMessage = "Assignment Name is required.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Assignment name must be between 4 and 100 characters.")]
    [Display(Name = "Title")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Assignment name must be between 10 and 100 characters.")]
    [Display(Name = "Description")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Maximum points is required.")]
    [Display(Name = "Max Points")]
    public required int MaxPoints { get; set; }
    [Required(ErrorMessage = "Due date is required.")]
    [Display(Name = "Due Date")]
    public DateTime DueDate { get; set; }

    public Course Course { get; set; }
}

