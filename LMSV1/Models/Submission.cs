using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSV1.Models
{
    public class Submission
    {
        public int SubmissionID { get; set; }  // Primary key

        [Display(Name = "Assignment ID")]
        public int? AssignmentID { get; set; }  // Foreign Key*/ do not want cascading delete.
        public Assignment Assignment { get; set; }  // If Assignment gets deleted still want to have submission.

        [Required]
        [Display(Name = "Student ID")]
        public int UserID { get; set; }  // Foreign Key*/
        public User User { get; set; }

        [Display(Name = "File Submission")]
        public string? FileName { get; set; }

        [StringLength(5000)]
        [Display(Name = "Text Submission")]
        public string? TextSubmission { get; set; }

        public double? Score { get; set; }

        [Required]
        [Display(Name = "Submission Date and Time")]
        public DateTime SubmissionDate { get; set; }
    }
}
