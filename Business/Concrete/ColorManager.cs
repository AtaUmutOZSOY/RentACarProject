using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules.Abstract;
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
        IColorBusinessRules _colorBusinessRules;
        public ColorManager(IColorDal colorDal, IColorBusinessRules colorBusinessRules)
        {
            _colorDal = colorDal;
            _colorBusinessRules = colorBusinessRules;
        }
        public ColorManager()
        {

        }

        public IResult Add(Color color)
        {
            var notExistColor = _colorBusinessRules.CheckColor(color.ColorName);
            if (notExistColor.Success)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddAdd);
            
        }

        public IResult Delete(Color color)
        {
            var isExistColor = _colorBusinessRules.CheckColor(color.ColorName);
            if (isExistColor.Success)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ActionMessages.SuccedRemove);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddRemove);
        }

        public IResult Update(Color color)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Color>> GetAllColor()
        {
            var colors = _colorDal.GetAll();
            if (colors.Count == 0)
            {
                return null;
            }
            return new SuccessDataResult<List<Color>>(colors);
        }

        public IDataResult<Color> GetColorByColorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
