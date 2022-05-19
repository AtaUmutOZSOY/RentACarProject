using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
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
        [HttpPost("AddBrand")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
            
            
            

        [HttpDelete("DeleteRental")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok("Silme Başarılı");
            }
            return BadRequest();
         
        }
         
         
        [HttpPost("UpdateRentals")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound();
        }
            
            
            

        [HttpGet("GetAllRentals")]

        public IActionResult GetAll()
        {
            var result = _rentalService.GetAllRentals();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
         
         
         


        [HttpGet("GetRentalByRentalId")]

        public IActionResult Ge(int id)
        {
            var result = _rentalService.GetRentalByRentalId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound();
         
        }
    }
}
