using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Common;

public static class GenerateJwtString
{
    public static string GenerateJwt(this User user, string secretKey, DateTime expDate)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expDate,
            signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}