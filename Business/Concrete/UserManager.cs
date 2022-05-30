using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
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
    public class UserManager : BaseManager<User>, IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var existUser = BusinessRulesValidator.Run(CheckExistUser(user.Id));
            if (existUser != null)
            {
                var claims = _userDal.GetClaims(user);
                return new SuccessDataResult<List<OperationClaim>>(claims.ToList());
            }
            return null;
        }

        public IDataResult<User> GetUser(string email)
        {
            var user = _userDal.Get(x=>x.Email == email);
            if (user != null )
            {
                return new SuccessDataResult<User>(user);
            }
            return null;
        }

        public IResult CheckExistUser(int id)
        {
            var result = _userDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}
