using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPost("addRental")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
            
            
            

        [HttpDelete("deleteRental")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok("Silme Başarılı");
            }
            return BadRequest();
         
        }
         
         
        [HttpPost("updateRental")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound();
        }        
    }
}
