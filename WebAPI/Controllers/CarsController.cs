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
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
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
        [HttpGet("getAllCars")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getCarDetailByCarId")]       
        public IActionResult GetCarDetail(int id)
        {
            var result = _carService.GetCarDetailByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("getCarDetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
