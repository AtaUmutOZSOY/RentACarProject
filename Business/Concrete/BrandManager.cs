using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;

using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs.BrandDTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : BaseManager<Brand>,IBrandService
    {
        IBrandDal _brandDal;
       
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
           
        }

        public override IResult Add(Brand entity)
        {
            var result = BusinessRulesValidator.Run(CheckExistBrand(entity.BrandId));
            if (result.Success)
            {
                return base.Add(entity);
            }
            return new ErrorResult(Messages.ActionMessages.AlreadyExist);
        }

        public IResult CheckExistBrand(int brandId)
        {
            var result = _brandDal.Get(x=>x.BrandId == brandId);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
