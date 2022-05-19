using Business.Constants;
using Business.ValidationRules.BusinessRules.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.BusinessRules.Concrete
{
    public class ColorBusinessRules : IColorBusinessRules
    {
        IColorDal _colorDal;
        public ColorBusinessRules(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult CheckColor(string colorName)
        {
           var result =  _colorDal.Get(x=>x.ColorName == colorName);
            if (result == null)
            {
                return new SuccessResult(true);
            }
            return new ErrorResult(Messages.ColorMassages.ColorExistMassage);
        }
    }
}
