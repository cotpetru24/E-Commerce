using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var token = _userService.RegisterAsync(dto);
            return Ok(new { token });

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            return Ok(new { token });

        }

        //Protected route
        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var username = await _userService.GetCurrentUsernameAsync(User);
            return Ok(new { username });
        }
    }
}
