using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : BaseManager<Car>,ICarService
    {
        
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
            
        }

       

        public IResult CheckExistCarByCarId(int carId)
        {
            var result = _carDal.Get(x => x.CarId == carId);
            if (result != null)
            {
                return new ErrorResult(Messages.ActionMessages.AlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
