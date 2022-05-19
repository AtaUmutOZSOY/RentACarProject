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
        public BrandBusinessRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult CheckExistBrand(string brandName)
        {
            var existBrandResult = _brandDal.Get(x=>x.BrandName== brandName);
            if (existBrandResult != null)
            {
                return new ErrorResult(false);
            }
            return new SuccessResult(true);
                
        }

        public IResult CheckExistBrandForUpdate(string brandName)
        {
            var exisBrandResult = _brandDal.Get(x=>x.BrandName == brandName);
            return new SuccessResult(true);
        }
    }
}
