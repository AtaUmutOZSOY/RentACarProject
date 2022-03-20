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

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult("Araç Başarılı Bir Şekilde Eklenmiştir");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araç Başarılı Bir Şekilde Silinmiştir");
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetCarByCarId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x=>x.CarId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araç Başarılı Bir Şekilde Güncellenmiştir");
        }
    }
}
