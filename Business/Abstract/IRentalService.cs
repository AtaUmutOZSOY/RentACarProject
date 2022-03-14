using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Create(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<Rental> GetRental(Rental rental);

        IDataResult<List<Rental>> GetAllRentals();

    }
}
