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
    public int AssignmentID { get; set; }  // Primary key

    [Required(ErrorMessage = "Assignment Name is required.")]
    [StringLength(100)]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(256)]
    [Display(Name = "Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Maximum points is required.")]
    [Display(Name = "Max Points")]
    public int MaxPoints { get; set; }

    [Required(ErrorMessage = "Due date is required.")]
    [Display(Name = "Due Date")]
    [DataType(DataType.DateTime)]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage ="Submission Type is required.")]
    [Display(Name = "Submission Type")]
    public SubmissionType SubmissionType { get; set; }

    [Required]
    [Display(Name = "Course ID")]
    public int CourseID { get; set; }  // Foreign Key
    public Course Course { get; set; }

    public ICollection<Submission>? Submissions { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}

public enum SubmissionType
{
    [Display(Name = "File Upload")]
    FileUpload,
    [Display(Name = "Text Entry")]
    TextEntry
}


