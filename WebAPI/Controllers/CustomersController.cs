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
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteRental")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok("Silme Başarılı");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("UpdateRentals")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllRentals")]

        public IActionResult GetAll()
        {
            var result = _customerService.GetAllColor();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpGet("GetRentalByRentalId")]

        public IActionResult Ge(int id)
        {
            var result = _customerService.GetCustomerByCustomerId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
