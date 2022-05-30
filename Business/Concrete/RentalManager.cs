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
    public class RentalManager : BaseManager<Rental>,IRentalService
    {
        IRentalDal _rentalDal;
      

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
            
        }

       

        public IResult CheckExistRentalByRentalId(int rentalId)
        {
            var result = _rentalDal.Get(x => x.RentalId == rentalId);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
