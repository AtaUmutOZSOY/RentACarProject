using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult Delete(Rental rental)
        {
           _rentalDal.Delete(rental);
            return new SuccessResult("Silme Başarılı");
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetBrandByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Güncelleme Başarılı");
        }
    }
}
