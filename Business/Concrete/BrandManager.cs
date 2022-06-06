using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.DataAccess.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs.BrandDTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) 
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand entity)
        {
            var result = BusinessRulesValidator.Run(CheckExistBrand(entity.BrandName));
            if (result == null)
            {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.AlreadyExist);
        }

        public IResult CheckExistBrand(string brandName)
        {
            var result = _brandDal.Get(x=>x.BrandName == brandName);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var brands = _brandDal.GetAll();
            if (brands != null)
            {
                return new SuccessDataResult<List<Brand>>(brands);
            }
            return new ErrorDataResult<List<Brand>>();
        }

        public IDataResult<Brand> GetById(int id)
        {
            var brand = _brandDal.Get(x => x.BrandId == id);
            if (brand != null)
            {
                return new SuccessDataResult<Brand>(brand);
            }
            return new ErrorDataResult<Brand>(Messages.ActionMessages.NotExist);
        }

        public IResult Update(Brand brand)
        {
            var brandCheck = BusinessRulesValidator.Run(CheckExistBrand(brand.BrandName));
            if (!brandCheck.Success)
            {
                _brandDal.Update(brand);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
