using Core.Entity.DTOs;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(BrandDTO brandDto);
        IResult Delete(BrandDTO brand);
        IResult Update(BrandDTO brand);
        IDataResult<List<Brand>> GetAllBrands();
       
    }
}
