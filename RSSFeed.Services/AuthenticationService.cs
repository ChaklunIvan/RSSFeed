using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RSSFeed.Models.Constans;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;
using RSSFeed.Services.Extensions;
using RSSFeed.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RSSFeed.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<User> ValidateUserAsync(AuthenticationRequest authenticationRequest)
        {
            var user = await _userManager.FindByNameAsync(authenticationRequest.UserName);
            var verifyPassword = await _userManager.CheckPasswordAsync(user, authenticationRequest.Password);

            if(verifyPassword == false)
            {
                throw new UnauthorizedAccessException();
            }

            return user;
        }

        public async Task<string> CreateTokenAsync(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = user.GetClaims(await _userManager.GetRolesAsync(user));
            var tokenOptions = signingCredentials.GenerateTokenOptions(claims, _configuration);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection(JwtConstans.JwtSettings);
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetSection(JwtConstans.Key).Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
