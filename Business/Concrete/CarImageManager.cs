using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage));
            if (result.Success)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.SuccedAdd);

            }
            else
            {
                return new ErrorResult(Messages.UnsucceddAdd);
            }
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.SuccedRemove);
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>();
        }

        public IDataResult<CarImage> GetCarImageById(int id)
        {
            var result = _carImageDal.Get(x => x.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.SuccedUpdate);
        }

        /// <summary>
        /// This function count car images. 16.04.2022
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public IResult CheckCarImageCount(CarImage carImage)
        {
            var carImageCount = _carImageDal.CarImageCount(carImage);
            if (carImageCount == 5)
            {
                return new ErrorDataResult<CarImage>("Araç Resmi En Fazla 5 Adet Olabilir");
            }
            return null;
        }

        public IDataResult<List<CarImage>> ListCarImages(CarImage carImage)
        {
            var result = _carImageDal.GetListOfCarImagesByCarId(carImage);
            return new SuccessDataResult<List<CarImage>>(result.Data);
        }
        public IDataResult<List<CarImage>> ShowDefaultImageofCar(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage));
            if (result == null)
            {
                
            }
            return null;
        }
    }
}
