using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("AddBrand")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
            



        [HttpDelete("DeleteRental")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok("Silme Başarılı");
            }
            return BadRequest();
        }
        
        
        

        [HttpPost("UpdateRentals")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound();
        }
         
         
         

        [HttpGet("GetAllRentals")]

        public IActionResult GetAll()
        {
            var result = _customerService.GetAllColor();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
         
         
         


        [HttpGet("GetRentalByRentalId")]

        public IActionResult Ge(int id)
        {
            var result = _customerService.GetCustomerByCustomerId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
            
            
            
