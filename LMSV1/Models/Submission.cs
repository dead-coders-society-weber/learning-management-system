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
                                               // If Assignment gets deleted still want to have submission.
        public Assignment Assignment { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public int UserID { get; set; }  // Foreign Key*/
        public User User { get; set; }
        [Required]
        [Display(Name = "File Submission")]
        public string? FileName { get; set; }
        [StringLength(5000)]
        [Display(Name = "Text Submission")]
        public string? TextSubmission { get; set; }
        public double? Score { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }

        
    }
}
