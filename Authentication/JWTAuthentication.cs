using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Vee_Tailoring.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using Vee_Tailoring.Entities.Identity;

namespace Vee_Tailoring.Authentication;

public class JWTAuthentication : IJWTAuthentication
{
    public string _key;
    public JWTAuthentication(string key)
    {
        _key = key;
    }
    public string GenerateToken(GetUserDto getUserDto)
    {
    List<Claim> claims = new List<Claim>();
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(_key);
        claims.Add(new Claim(ClaimTypes.Name, getUserDto.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, getUserDto.Email));
        foreach (var role in getUserDto.Role)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.Now,
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature),
            Audience = "Vee Tailoring Users",
            Issuer = "Vee Tailoring Eye",
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}