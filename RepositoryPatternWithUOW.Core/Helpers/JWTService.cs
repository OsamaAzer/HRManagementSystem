using Microsoft.IdentityModel.Tokens;
using RepositoryPatternWithUOW.Core.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryPatternWithUOW.Core.Helpers
{
    public class JwtService(JWT jwt)
    {
        public string GenerateToken(TokenRequestDTO tokenRequest)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, tokenRequest.Username),
                new Claim(ClaimTypes.Role, tokenRequest.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(jwt.LifeTimeInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
