using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entity.DTOs;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Add(BrandDTO brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult Delete(BrandDTO brandDto)
        {
            var result = _brandService.Delete(brandDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
        [HttpPost("UpdateBrands")]
        public IActionResult Update(BrandDTO brandDto)
        {
            var result = _brandService.Update(brandDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpGet("GetAllBrands")]

       public IActionResult GetAll() 
        {
           var result =  _brandService.GetAllBrands();
            if (result.Success)
            {
                return Ok(result.Data);
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
