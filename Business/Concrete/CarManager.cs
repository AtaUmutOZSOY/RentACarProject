using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs.CarDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ActionMessages.SuccedAdd);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ActionMessages.SuccedRemove);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var cars = _carDal.GetAll();
            if (cars != null)
            {
                return new SuccessDataResult<List<Car>>(cars);
            }
            return null;
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsWithDetail()
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<Car> GetByCarId(int id)
        {
            var result = _carDal.Get(x => x.CarId == id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return null;
        }

        public IResult Update(Car car)
        {
            var result = BusinessRulesValidator.Run(CheckExistCarForUpdate(car));
            if (result.Success)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);
        }


        private IResult CheckExistCarForUpdate(Car car)
        {
            var result =_carDal.Get(x => x.CarId == car.CarId);
            if (result == null)
            {
                return new ErrorResult(false);
            }
            return new SuccessResult(true);
        }
    }
}
