using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandMessages.SuccedBrandAdd);
            }
            else
            {
                return new ErrorResult(Messages.BrandMessages.UnsuccedBrandAdd);
            }
        }
        //Mesai saatleri içerisinde silme işlemi yapılabilir bunu yaz. Bu iş kuralı.
        public IResult Delete(Brand brand)
        {
            //validasyon
            var existEntity = _brandDal.Get(x => x.BrandId == brand.BrandId);

            if (existEntity != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandMessages.SuccedBrandRemove);
            }
            else
            {
                _brandDal.Delete(brand);
                return new ErrorResult(Messages.BrandMessages.UnsuccedBrandRemove);
            }
        }





        public IResult Update(Brand brand)
        {
            var existEntity = _brandDal.Get(x => x.BrandId == brand.BrandId);


            if (existEntity != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandMessages.SuccedBrandUpdate);
            }
            else
            {
                return new ErrorResult(Messages.BrandMessages.UnsuccedBrandUpdate);
            }
        }


        public IDataResult<List<Brand>> GetAllBrands()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetBrandByBrandId(int id)
        {
            var brand =  _brandDal.Get(x=>x.BrandId == id);
            return new SuccessDataResult<Brand>(brand.BrandName);
        }
    }
}
