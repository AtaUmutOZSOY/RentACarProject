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

        [HttpGet("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return null;
        }
    }
}
