using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Models;

/*
 * SignUp screen consists of username/email, password, firstname, 
 * lastname, bithdate information and a button called SignUp.
 * When User Sign up, take them to Welcome Screen. When user SignUp, 
 * all the information about the user should be stored in the database. 
 * You don't need to encrypt or hash the password. Just store the password
 * as plain text for this assignment.
 */
public class User : IdentityUser<int>
{
    [Required]
    public override int Id { get; set; } // Primary key

    [Required(ErrorMessage = "Username/Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [Display(Name = "Username/Email")]
    public override required string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    public string FullName { get { return LastName + ", " + FirstName; } }

    [Required(ErrorMessage = "Birthdate is required.")]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    public required string Role { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    [DataType(DataType.PostalCode)]
    public string? Zip { get; set; }

    [DataType(DataType.Url)]
    public string? Link1 { get; set; }

    [DataType(DataType.Url)]
    public string? Link2 { get; set; }

    [DataType(DataType.Url)]
    public string? Link3 { get; set; }

    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }

    public long TuitionAmount { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }
    public ICollection<Course>? Courses { get; set;}
    public ICollection<Submission>? Submissions { get; set; }
    public ICollection<Notification>? Notifications { get; set; }
}