using Business.Constants;
using Business.ValidationRules.BusinessRules.Abstract;
using Core.Entity.Concrete;
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
    public class AuthBusinessRules : IAuthBusinessRules
    {
        IUserDal _userDal;
        public AuthBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult CheckUserExist(string email)
        {
            var userCheckResult = _userDal.Get(x=>x.Email == email);
            if (userCheckResult == null)
            {
                return new SuccessResult(true);
            }
            return new ErrorResult(Messages.UserMassages.UserAlreadyExist);
        }

        public IDataResult<User> CheckUserExistForLogin(string email)
        {
            var userCheckForLogin = _userDal.Get(x => x.Email == email);
            if (userCheckForLogin != null)
            {
                return new SuccessDataResult<User>(userCheckForLogin, true);
            }
            return new ErrorDataResult<User>(Messages.UserMassages.UserNotFound);
        }

        //public IResult CheckUserExistForLogin(string email)
        //{
        //   var userCheckForLoginResult = _userDal.Get(x=>x.Email == email);
        //    if (userCheckForLoginResult != null)
        //    {
        //        return new SuccessResult(Messages.AuthMessages.SuccessLogin);
        //    }
        //    return new ErrorResult(Messages.AuthMessages.UserNotExist);
        //}


    }
}
