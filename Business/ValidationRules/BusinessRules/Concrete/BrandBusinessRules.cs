using Business.ValidationRules.BusinessRules.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.BusinessRules.Concrete
{
    public class BrandBusinessRules : IBrandBusinessRules
    {
        IBrandDal _brandDal;
        public IResult CheckExistBrand(int id)
        {
            var existBrandResult = _brandDal.Get(x=>x.BrandId == id);
            if (existBrandResult == null)
            {
                return new SuccessResult(true);
            }
            return new ErrorResult(false);
        }
    }
}
