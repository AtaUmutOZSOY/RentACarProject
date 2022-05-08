using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Business.ValidationRules.BusinessRules.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        IBrandBusinessRules _brandBusinessRules;
        public BrandManager(IBrandDal brandDal, IBrandBusinessRules brandBusinessRules)
        {
            _brandDal = brandDal;
            _brandBusinessRules = brandBusinessRules;   
        }
        
        [ValidationAspect(typeof(BrandValidator))]

        public IResult Add(Brand brand)
        {
            var IsExistBrand = BusinessRulesValidator.Run(_brandBusinessRules.CheckExistBrand(brand.BrandId));
            if (IsExistBrand.Success)
            {
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddAdd);
        }
        
        
        
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            var isBrandExist = BusinessRulesValidator.Run(_brandBusinessRules.CheckExistBrand(brand.BrandId));

            if (isBrandExist.Success)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.ActionMessages.SuccedRemove);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddRemove);
        }



        [ValidationAspect(typeof(BrandValidator))]

        [SecuredOperation("Brand.add,admin")]

        public IResult Update(Brand brand)
        {
            var isBrandExist = BusinessRulesValidator.Run(_brandBusinessRules.CheckExistBrand(brand.BrandId));
            if (isBrandExist.Success)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.UnsuccedUpdate);
        }


        public IDataResult<List<Brand>> GetAllBrands()
        {
            var brandList = _brandDal.GetAll();
            if (brandList == null)
            {
                return null;
            }
            return new SuccessDataResult<List<Brand>>(brandList);
        }


        public IDataResult<Brand> GetBrandByBrandId(int id)
        {
            var brandById =  _brandDal.Get(x=>x.BrandId == id);
            if (brandById != null)
            {
                return new SuccessDataResult<Brand>(brandById);
            }
            return null;
        }

    }
}
