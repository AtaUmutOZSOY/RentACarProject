using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public ColorManager()
        {

        }
        public IResult Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorMassages.SuccedColorAdd);
            }
            else
            {
                return new ErrorResult(Messages.ColorMassages.UnsuccedColorAdd);
            }
           
            
        }

        public IResult Delete(Color color)
        {
           _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorMassages.SuccedColorRemove);
        }

        public IDataResult<List<Color>> GetAllBrands()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll()); 
        }

        public IDataResult<Color> GetBrandByColorName(Color color)
        {
            
            return new SuccessDataResult<Color>(_colorDal.Get(x => x.ColorName == color.ColorName));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorMassages.SuccedColorUpdate);
        }
    }
}
