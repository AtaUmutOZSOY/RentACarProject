using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : BaseManager<Color>, IColorService
    {
        IColorDal _colorDal;
        
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
            
        }

       
        public IResult CheckExistColorById(int colorId)
        {
            var color = _colorDal.Get(x => x.ColorId == colorId);
            if (color != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }
    }
}
