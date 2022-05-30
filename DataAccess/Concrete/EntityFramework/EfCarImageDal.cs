using Core.DataAccess.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarProjectContext>, ICarImageDal
    {
        public int CarImageCount(CarImage carImage)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var result = context.CarImages.Count(x => x.CarId == carImage.CarId);
                return result;  
                
            }
        }

        //public IDataResult<CarImage> GetDefaultCarImage(Expression<Func<CarImage>>filter,bool bo) 
        //{
        //    using (RentACarProjectContext context = new RentACarProjectContext())
        //    {
        //        var result = context.CarImages.SingleOrDefault(filter,filter);
        //        return result;
        //    }
        //}

        public IDataResult<List<CarImage>> GetListOfCarImagesByCarId(CarImage carImage)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                List<CarImage> carImages = new List<CarImage>();
                context.CarImages.ToList().ForEach(carImage => carImages.Add(carImage));
                return new SuccessDataResult<List<CarImage>>(carImages);
                
                
            }
        }
        //public IDataResult<List<CarImage>> GetDefaultCarImage()
        //{
        //    //
        //    using(RentACarProjectContext context = new RentACarProjectContext())
        //}
    }
}
