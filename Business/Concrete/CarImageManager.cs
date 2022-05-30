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
    public class CarImageManager : BaseManager<CarImage>,ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        
        

        public IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId);
            if (result.Count<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImagesMassages.CarImageCountsError);
        }
        //Mesaj için kod refactoring yapılmalı 
        public IResult CheckExistCarImageById(int id)
        {
            var result = _carImageDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new ErrorResult(Messages.ActionMessages.UnsuccedUpdate);
            }
            return new SuccessResult();
        }
    }
}
