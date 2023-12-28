using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TodoProject.Data;
using TodoProject.Models;

namespace TodoProject.Utils;

public class JwtTokenManager : IJwtTokenManager
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _applicationDbContext;
    public JwtTokenManager(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ApplicationDbContext applicationDbContext)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _applicationDbContext = applicationDbContext;
    }
    public string CreateToken(ApplicationUser user)
    {
        List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString())
            };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public string? GetToken()
    {
        return _httpContextAccessor.HttpContext?.Request.Headers.Authorization.FirstOrDefault();
    }

    public bool IsValid()
    {
        if(_applicationDbContext.TokenBlackList.Any(t => t.Token.Equals(GetToken())))
            return false;
        return true;
    }

    public string GetCurrentUserId() {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        var userId = handler.ReadJwtToken(GetToken().Substring(7)).Claims.ElementAt(0).Value.ToString();
        return userId;
    }

}