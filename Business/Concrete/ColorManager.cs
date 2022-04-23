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
            _colorDal.Add(color);
            return new SuccessResult("Renk Başarılı bir şekilde eklenmiştir");
        }

        public IResult Delete(Color color)
        {
           _colorDal.Delete(color);
            return new SuccessResult("Renk Başarılı Bir Şekilde Silinmiştir");
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Güncelleme Başarılı");

        }

        public IDataResult<List<Color>> GetAllColor()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetColorByColorId(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(x=>x.ColorId == id));
        }
    }
}
