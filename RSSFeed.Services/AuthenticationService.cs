using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;
using RSSFeed.Services.Interfaces;

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

        public async Task<bool> ValidateUserAsync(AuthenticationRequest authenticationRequest)
        {
            var user = await _userManager.FindByNameAsync(authenticationRequest.UserName);
            return await _userManager.CheckPasswordAsync(user, authenticationRequest.Password);
        }
    }
}
