using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("AddCar")]
        public IActionResult Add(Car car)
        {
           var result =  _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpDelete("DeleteCar")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("UpdateCar")]
        public IActionResult Update(Car car) 
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        
        }
        [HttpGet("GetAllCars")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();
            if (result.Success)
            {
                return Ok(result.Data);

            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetCarByCarId")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.GetCarByCarId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
