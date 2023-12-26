using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TodoProject.Models;

namespace TodoProject.Utils;

public class JwtTokenManager: IJwtTokenManager
{
    private readonly IConfiguration _configuration;
    public JwtTokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
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
}