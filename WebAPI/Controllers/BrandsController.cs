using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        
        [HttpPost("AddBrand")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
        [HttpPost("UpdateBrands")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpGet("GetAllBrands")]

        public IActionResult GetAllBrand() 
        {
           var result =  _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return null;

        }
        //[HttpGet("GetBrandsByBrandId")]

        //public IActionResult GetByBrandId(int id)
        //{
        //    var result = _brandService.GetBrandByBrandId(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data) ;
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

       
    }
}
