using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AIM.BookStoreManagement.Dto.DTO;
using Microsoft.IdentityModel.Tokens;

namespace AIM.BookStoreManagement.JWT;

public class JwtService : IJwtService
{
    public string GenerateToken(UserDto user)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JwtKey")!)); // Get your secret key

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define the claims (data you want to include in the token)
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("Id", user.Id.ToString()),
            new Claim("Name ", user.Name)
        };

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("Issuer"),
            audience: Environment.GetEnvironmentVariable("Audience"),
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Token lifespan
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}