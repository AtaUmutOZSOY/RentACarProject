using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            var result = BusinessRulesValidator.Run(CheckExistColor(color.ColorName));
            if (result == null)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.AlreadyExist);
        }

        private IResult CheckExistColor(string colorName)
        {
            var result = _colorDal.Get(x => x.ColorName == colorName);
            if (result != null)
            {
                return new ErrorResult();
            }
            return null;
        }

        public IResult Delete(Color color)
        {
            var result = BusinessRulesValidator.Run(CheckExistColor(color.ColorName));
            if (result != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ActionMessages.SuccedRemove);
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var colors = _colorDal.GetAll();
            if (colors != null)
            {
                return new SuccessDataResult<List<Color>>(colors);
            }
            return null;
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            var color = _colorDal.Get(x => x.ColorId == id);
            return new SuccessDataResult<Color>(color);
        }

        public IDataResult<Color> GetByColorName(string name)
        {
            var color = _colorDal.Get(x => x.ColorName == name);
            return new SuccessDataResult<Color>(color);
        }

        public IResult Update(Color color)
        {
            var result = BusinessRulesValidator.Run(CheckExistColor(color.ColorName));
            if (result.Success)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);
        }
    }
}
