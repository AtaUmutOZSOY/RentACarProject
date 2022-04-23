using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("AddColor")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpDelete("DeleteColor")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("UpdateColor")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetColorList")]
        public IActionResult GetColors()
        {
            var result = _colorService.GetAllColor();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpGet("GetColorByColorId")]
        public IActionResult GetColorByColorId(int id)
        {
            var result = _colorService.GetColorByColorId(id);
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
