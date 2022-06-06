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

        [HttpPost("AddRental")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteRental")]
        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("UpdateRental")]
        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
        [HttpGet("GetAllRentals")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAllRental();
            if (result.Success)
            {
                return Ok(result);
            }
            return null;
        }
        [HttpGet("GetRentalById")]
        public IActionResult GetRentalById(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return null;
        }
        [HttpGet("GetRentalsWithDetail")]
        public IActionResult GetRentalsWithDetail()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return null;
        }

    }

}
