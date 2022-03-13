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
    public class CarManager : ICarService
    {
        IBrandDal _brandDal;
        ICarDal _carDal;
        public CarManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public Result Add(Car car)
        {
            if (DateTime.Now.Hour < 9  && DateTime.Now.Hour > 18.30)
            {
                return new ErrorResult(Messages.CarMassages.UnsuccedCarAdd);
            }
            else
            {
                var existBrand = _brandDal.Get(x => x.BrandId == car.BrandId);

                if (existBrand != null)
                {
                    _carDal.Add(car);
                }
                return new SuccessResult(Messages.CarMassages.SuccedCarAdd);

            }

        }

        public IResult Delete(Car car)
        {
            var existCar = _carDal.Get(x => x.CarId == car.CarId);

            if (existCar != null)
            {
                _carDal.Delete(car);
            }
            return new SuccessResult(Messages.CarMassages.SuccedCarRemove);
        }

        public IDataResult<List<Car>> GetAllBrands()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetBrandByCarName(Car car)
        {
            
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarName == car.CarName));
        }

        public IResult Update(Car brand)
        {
            var existEntity = _carDal.Get(x => x.CarId == brand.CarId);
            if (existEntity != null)
            {
                _carDal.Update(brand);
            }
            return new SuccessResult(Messages.CarMassages.SuccedCarUpdate);
        }
    }
}
