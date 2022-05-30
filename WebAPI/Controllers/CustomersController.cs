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

        [HttpPost("addCustomer")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
            



        [HttpDelete("deleteCustomer")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok("Silme Başarılı");
            }
            return BadRequest();
        }
        
        
        

        [HttpPost("updateCustomer")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound();
        }
         
         
         

        [HttpGet("getAllCustomers")]

        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
         
         
         


        [HttpGet("getCustomerByCustomerId")]

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
            
            
            
