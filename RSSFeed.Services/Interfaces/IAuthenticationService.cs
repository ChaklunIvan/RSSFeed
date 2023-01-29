using RSSFeed.Models.Requests;

namespace RSSFeed.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUserAsync(AuthenticationRequest authenticationRequest);
    }
}
