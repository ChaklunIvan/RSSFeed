using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;

namespace RSSFeed.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> ValidateUserAsync(AuthenticationRequest authenticationRequest);
        Task<string> CreateTokenAsync(User user);
    }
}
