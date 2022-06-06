using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.RentalDTOs;
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
            return new SuccessResult(Messages.ActionMessages.SuccedAdd);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ActionMessages.SuccedRemove);
        }

        public IDataResult<List<Rental>> GetAllRental()
        {
            var result = _rentalDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Rental>>(result);
            }
            return null;
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            var rentals = _rentalDal.Get(x => x.RentalId == id);
            if (rentals != null)
            {
                return new SuccessDataResult<Rental>(rentals);
            }
            return null;
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            var rentalDetails = _rentalDal.GetAllRentalsWithDetail();
            if (rentalDetails != null)
            {
                return new SuccessDataResult<List<CarRentalDetailDto>>(rentalDetails);
            }
            return null;
        }

        public IResult Update(Rental rental)
        {
            var result = BusinessRulesValidator.Run(CheckExistRentalById(rental.RentalId));
            
            if (result.Success)
            {   
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);
        }
        private IResult CheckExistRentalById(int rentalId)
        {
            var result = _rentalDal.Get(x => x.RentalId == rentalId);
            
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


            
    }
}
