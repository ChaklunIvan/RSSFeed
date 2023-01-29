using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RSSFeed.Models.Constans;
using RSSFeed.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RSSFeed.Services.Extensions
{
    public static class TokenOptionsExtensions
    {
        public static List<Claim> GetClaims(this User user, IEnumerable<string> roles)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName)};

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public static JwtSecurityToken GenerateTokenOptions(this SigningCredentials signingCredentials, List<Claim> claims, IConfiguration configuration) 
        {
            var jwtSettings = configuration.GetSection(JwtConstans.JwtSettings);

            var tokenOptions = new JwtSecurityToken
                (
                issuer: jwtSettings.GetSection(JwtConstans.Issuer).Value,
                audience: jwtSettings.GetSection(JwtConstans.Audience).Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }
    }
}
