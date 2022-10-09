using System.Security.Claims;
using System.Text;
using ClassBook.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ClassBook.BLL.Authorization;

public static class TokenHandler
{
    internal static SecurityTokenDescriptor GenerateTokenDescriptor(User user, string JwtKey)
    {
        var key = Encoding.ASCII.GetBytes(JwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };


        return tokenDescriptor;
    }
}