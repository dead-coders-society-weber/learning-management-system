using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSV1.Models
{
    public class Submission
    {
        public int SubmissionID { get; set; }  // Primary key

        /*[Required]
        public int AssignmentID { get; set; }  // Foreign Key*/

        /*[Required]
        public int UserID { get; set; }  // Foreign Key*/

        
        [StringLength(5000)]
        [Display(Name = "Text Submission")]
        public string TextSubmission { get; set; }

       /* public Assignment Assignment { get; set; }
        public User User { get; set; }*/
    }
}
