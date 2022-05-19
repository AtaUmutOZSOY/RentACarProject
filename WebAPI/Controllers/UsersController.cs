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

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
           var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
            
            

            
        
        [HttpPost("UpdateUser")]
         public IActionResult UpdateUser(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
         
         
         

        [HttpGet("GetAllUsers")]
        
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
        [HttpGet("GetUserById")]
        public  IActionResult GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
            
            
            
            
        

       

