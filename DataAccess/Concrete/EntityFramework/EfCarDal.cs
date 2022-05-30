using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs.CarDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RentACarProjectContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var result = from c in context.Carss
                              join b in context.Brands on
                              c.BrandId equals b.BrandId
                              join co in context.Colors on
                              c.ColorId equals co.ColorId
                              select new CarDetailDto()
                              {
                                  CarId = c.CarId,
                                  BrandName = b.BrandName,
                                  ColorName = co.ColorName
                              };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }




    }
}
