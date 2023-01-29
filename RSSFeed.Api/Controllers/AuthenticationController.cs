using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSSFeed.Models.Requests;
using RSSFeed.Services.Interfaces;

namespace RSSFeed.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            var user = await _authenticationService.ValidateUserAsync(authenticationRequest);

            return Ok(new { Token = await _authenticationService.CreateTokenAsync(user) });
        }
    }
}
