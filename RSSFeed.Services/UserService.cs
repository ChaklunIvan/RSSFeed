using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;
using RSSFeed.Services.Interfaces;

namespace RSSFeed.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(RegisterRequest registerRequest) 
        {
            var user = _mapper.Map<User>(registerRequest);
            await _userManager.CreateAsync(user);
        }
    }
}
