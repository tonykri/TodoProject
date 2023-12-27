using System.ComponentModel.DataAnnotations;

namespace TodoProject.Dto;

public class UserSignupDto
{
    [MinLength(1)]
    public required string FirstName { get; set; }
    [MinLength(1)]
    public required string LastName { get; set; }
    [MinLength(1), EmailAddress]
    public required string Email { get; set; }
    [MinLength(1)]
    public required string Password { get; set; }
}