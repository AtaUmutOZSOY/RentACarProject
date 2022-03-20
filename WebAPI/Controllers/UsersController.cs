using Business.Abstract;
using Business.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("getall")]
        
        public IActionResult GetUsers()
        {
            var result = _userService.GetAllUsers();
            
            if (result.Data != null)
            {
               return Ok(result.Data);
            }
            else
            {
                return BadRequest();
            }
            
        }
        

       

            
    }
}
