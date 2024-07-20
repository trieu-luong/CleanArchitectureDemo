using CleanArchitectureDemo.Application.Configuration;
using CleanArchitectureDemo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CleanArchitectureDemo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<EmailSettings> _emailSettings;

        public UsersController(IUserService userService, IOptions<EmailSettings> emailSettings)
        {
            _userService = userService;
            _emailSettings = emailSettings;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetListUser();
            //users.FirstOrDefault().Name = _emailSettings.Value.SenderName;
            return Ok(users);
        }
    }
}
