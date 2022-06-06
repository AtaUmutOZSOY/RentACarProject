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
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var usertoLogin = _authService.Login(userForLoginDto);
            if (usertoLogin.Success)
            {
                var result = _authService.CreateAccessToken(usertoLogin.Data);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            
            var registiry =  _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            if (registiry.Success)
            {   
                var result = _authService.CreateAccessToken(registiry.Data);
                
                return Ok(registiry.Message);
            }
            return BadRequest(registiry.Message);
            
        }

        
    }
}
