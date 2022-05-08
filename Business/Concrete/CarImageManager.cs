using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
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
            var carImageValidation = BusinessRules.Run(CheckCarImageCount(carImage));

            if (carImageValidation.Success)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);

            }
            else
            {
                return new ErrorResult(Messages.ActionMessages.UnsucceddAdd);
            }
        }

        public IResult Delete(CarImage carImage)
        {
            var isExist = _carImageDal.GetAll();
            var isExistCount = isExist.Count();
            if (isExistCount != 0)
            {
                return new SuccessResult(Messages.ActionMessages.SuccedRemove);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddRemove);   
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            var result = _carImageDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(result.ToList());
            }
            return null;
        }


        public IDataResult<CarImage> GetCarImageById(int id)
        {

            var result = _carImageDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }
            return null;

        }

        public IResult Update(CarImage carImage)
        {
            var IsExist = BusinessRulesValidator.Run(CheckExistCarImage(carImage.Id));

            if (IsExist.Success == true)
            {
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.UnsuccedUpdate);
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

        public IDataResult<List<CarImage>> ShowDefaultImageofCar(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage));
            if (result == null)
            {
                
            }
            return null;
        }

        public IDataResult<CarImage> CheckExistCarImage(int id)
        {
            var isExist = _carImageDal.Get(x=>x.Id == id);
            if (isExist == null)
            {
                return new ErrorDataResult<CarImage>();
            }
            return new SuccessDataResult<CarImage>();
        }
    }
}
