using System.ComponentModel.DataAnnotations;

namespace TodoProject.Dto;

public class UserLoginDto
{
    [MinLength(1), EmailAddress]
    public required string Email { get; set; }
    [MinLength(1)]
    public required string Password { get; set; }
}