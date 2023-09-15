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
public class User
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }
    public Boolean Instructor { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    [DataType(DataType.PostalCode)]
    public string? Zip { get; set; }
}