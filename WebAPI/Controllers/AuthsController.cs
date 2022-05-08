using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
             _authService = authService;
        }

        [HttpGet("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {

            var registiry = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (registiry.Success)
            {
                return Ok(registiry.Message);
            }
            return BadRequest(registiry.Message);
        }

        [HttpGet("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var login = _authService.Login(userForLoginDto);
            if (login.Success)
            {
                return Ok(login);
            }
            return NotFound(login.Message);
        }
    }
}
