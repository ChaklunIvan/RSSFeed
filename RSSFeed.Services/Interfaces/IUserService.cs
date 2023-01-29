using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;

namespace RSSFeed.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(RegisterRequest registerRequest);
    }
}
