using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public UserManager()
        {

        }

        public IResult Add(User user)
        {
            var existUser = _userDal.Get(x=>x.UserId == user.UserId);

            if (existUser == null)
            {
                _userDal.Add(user);
                return new SuccessResult("Kullanıcı Başarılı Bir Şekilde Eklendi");
            }
            else
            {

                return new ErrorResult("Kullanıcı Adı Zaten Var");
            }
        }

        public IResult Delete(User brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetBrandByUserName(User userName)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User brand)
        {
            throw new NotImplementedException();
        }
    }
}
