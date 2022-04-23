using Business.Abstract;
using Business.Constants;
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
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public BrandManager()
        {

        }
        //validation Eklemeye,silmeye,listelemeye vb gibi işlemler yapmaya çalıştığımız varlıkların
        //iş kurallarına dahil edilebilmesi için bu varlıkların veya nesnelerin yapısal olarak uygun
        //olup olmadığını kontrol etmeye validation denir.
        //BusinessRules

        [ValidationAspect(typeof(BrandValidator))]

        public IResult Add(Brand brand)
        {
            var context = new ValidationContext<Brand>(brand);
            //BrandValidator

            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.SuccedAdd);
            }
            else
            {
                return new ErrorResult(Messages.UnsucceddAdd);
            }
        }
        //Mesai saatleri içerisinde silme işlemi yapılabilir bunu yaz. Bu iş kuralı.
        
        
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            //validasyon
            var existEntity = _brandDal.Get(x => x.BrandId == brand.BrandId);

            if (existEntity != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.SuccedRemove);
            }
            else
            {
                _brandDal.Delete(brand);
                return new ErrorResult(Messages.UnsucceddRemove);
            }
        }



        [ValidationAspect(typeof(BrandValidator))]

        public IResult Update(Brand brand)
        {
            var existEntity = _brandDal.Get(x => x.BrandId == brand.BrandId);


            if (existEntity != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.SuccedUpdate);
            }
            else
            {
                return new ErrorResult(Messages.UnsuccedUpdate);
            }
        }


        public IDataResult<List<Brand>> GetAllBrands()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetBrandByBrandId(int id)
        {
            var brand =  _brandDal.Get(x=>x.BrandId == id);
            return new SuccessDataResult<Brand>(brand);
        }

    }
}
