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
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteCar")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();

        }

        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllCars")]
        public IActionResult GetAll()
        {
            var results = _carService.GetAll();
            return Ok(results);
        }

        [HttpGet("GetCarById")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.GetByCarId(id);
            if (result == null)
            {
                return null;
            }
            return Ok(result);
        }

        [HttpGet("GetAllCarsWithDetail")]
        public IActionResult GetAllCarsWithDetail()
        {
            var result = _carService.GetAllCarsWithDetail();
            if (result != null)
            {
                return Ok(result);
            }
            return null;
        }
    }
}
