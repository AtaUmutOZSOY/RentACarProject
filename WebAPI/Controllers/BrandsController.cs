using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
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
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok("Silme Başarılı");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("UpdateBrands")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllBrands")]

       public IActionResult GetAll() 
        {
           var result =  _brandService.GetAllBrands();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
           

        }
        [HttpGet("GetBrandsByBrandId")]

        public IActionResult GetByBrandId(int id)
        {
            var result = _brandService.GetBrandByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data) ;
            }
            else
            {
                return NotFound();
            }
        }

       
    }
}
