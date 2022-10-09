using System.IdentityModel.Tokens.Jwt;
using ClassBook.BLL.DTOs.Response;
using Microsoft.IdentityModel.Tokens;

namespace ClassBook.BLL.Authorization;

internal static class TokenGenerator
{
    public static TokenDto GetToken(SecurityTokenDescriptor tokenDescriptor)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);

        return new TokenDto(stringToken);
    }
}