using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entity.DTOs.CarDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetByCarId(int id);
        IDataResult<List<CarDetailDto>> GetAllCarsWithDetail();
    }
}
