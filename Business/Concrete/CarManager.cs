using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
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

        public CarManager(IBrandDal brandDal, ICarDal carDal)
        {
            _brandDal = brandDal;
            _carDal = carDal;
        }


        public IResult Add(Car car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetCarByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }

       
    }
}
