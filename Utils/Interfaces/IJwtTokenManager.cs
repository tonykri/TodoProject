using TodoProject.Models;

namespace TodoProject.Utils;

public interface IJwtTokenManager
{
    string CreateToken(ApplicationUser user);
    public string? GetToken();
    public bool IsValid();
    public string GetCurrentUserId();
}