using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Security.Domain.Services.Communication;

// If we want to register a new user, all attributes are required.
public class RegisterRequest
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}