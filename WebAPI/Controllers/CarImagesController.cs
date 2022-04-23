using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("AddCarImages")]
        public IActionResult AddCarImages(CarImage carImages)
        {
            var result = _carImageService.Add(carImages);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetCarImage")]
        public IActionResult GetCarImage(CarImage carImage)
        {
            var result = _carImageService.GetCarImageById(carImage.CarId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("DeleteCarImage")]
        public IActionResult DeleteCarImage (CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("UpdateCarImage")]
        public IActionResult UpdateCarImage(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpGet("GetAllCarImages")]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetAllCarImages();
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
