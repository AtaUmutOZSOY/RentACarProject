using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.CarDTOs;
using Entity.DTOs.RentalDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental, RentACarProjectContext>,IRentalDal
    {
        public List<CarRentalDetailDto> GetAllRentalsWithDetail(Expression<Func<CarRentalDetailDto, bool>> filter = null)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var result = from c in context.Carss
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join re in context.Rentals on c.CarId equals re.CarId
                             join cu in context.Customerss on re.CustomerId equals cu.CustomerId
                             join us in context.Users on cu.UserId equals us.Id
                             select new CarRentalDetailDto()
                             {
                                 BrandName = b.BrandName,
                                 CarId = c.CarId,
                                 CustomerFirstName = us.FirstName,
                                 CustomerLastName = us.LastName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
