using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest) 
        {
            if (registerRequest == null) 
            {
                return BadRequest("Invalid registration data");
            }
           var response = await _userService.Register(registerRequest);
            if (response == null || response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest) 
        {
            if (loginRequest == null) 
            {
                return BadRequest("Invalid login request");
            }
            var response = await _userService.Login(loginRequest);
            if (response == null || response.Success == false)
            {
                return Unauthorized(response);
            }

            return Ok(response);

        }
    }
}
