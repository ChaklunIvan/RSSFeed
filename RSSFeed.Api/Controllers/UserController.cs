using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;
using RSSFeed.Services.Interfaces;

namespace RSSFeed.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterRequest registerRequest)
        {
            await _userService.CreateUserAsync(registerRequest);

            return Ok();
        }
    }
}
