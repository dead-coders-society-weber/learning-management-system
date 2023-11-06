using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Models
{
    public class Notification
    {
        public int NotificationID { get; set; } // Primary key

        public NotificationEvent Event { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StudentID { get; set; } // Foreign key
        public User Student { get; set; }

        public int AssignmentID { get; set; } // Foreign key
        public Assignment Assignment { get; set; }
   }

    public enum NotificationEvent
    {
        [Description("Created")]
        AssignmentCreation,
        [Description("Graded")]
        AssignmentGraded,
    }
}
