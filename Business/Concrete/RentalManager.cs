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
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.BrandMessages.UnsuccedBrandAdd); //Düzenlenecek
        }

        public IResult Create(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.BrandMessages.SuccedBrandAdd);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetRental(Rental rental)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x=>x.RentalId == rental.RentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.BrandMessages.SuccedBrandUpdate);
        }
    }
}
