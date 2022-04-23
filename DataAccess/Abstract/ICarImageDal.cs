using Core.DataAccess.Abstract;
using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
        int CarImageCount(CarImage carImage);
        IDataResult<List<CarImage>> GetListOfCarImagesByCarId(CarImage carImage);
    }
}
