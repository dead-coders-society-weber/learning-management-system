using System.ComponentModel.DataAnnotations;

namespace LMSV1.Models
{
    public class Department
    {
        [Key]
        [StringLength(4)]
        public string DepartmentID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
