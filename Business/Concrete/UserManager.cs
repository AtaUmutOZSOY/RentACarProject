using Business.Abstract;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        { 
            var existUser = BusinessRulesValidator.Run(CheckExistUserByEmail(user.Email));
            if (existUser == null)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.ActionMessages.SuccedAdd);
            }
            return new ErrorResult(Messages.ActionMessages.UnsucceddAdd);
        }

        public IResult Delete(User user)
        {
            var existUser = BusinessRulesValidator.Run(CheckExistUserByEmail(user.Email));
            if (existUser != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserMassages.UserDeleted);
            }
            return new ErrorResult(Messages.UserMassages.UserNotFound);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            var allUserList = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(allUserList);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var queryResult = _userDal.Get(x=>x.Email == email);
            if (queryResult == null)
            {
                return null;
            }
            return new SuccessDataResult<User>(queryResult);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var existUser = BusinessRulesValidator.Run(CheckExistUserByEmail(user.Email));
            if (existUser != null)
            {
                var claims = _userDal.GetClaims(user);
                return new SuccessDataResult<List<OperationClaim>>(claims.ToList());
            }
            return null;
        }

        public IDataResult<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            var existUser = BusinessRulesValidator.Run(CheckExistUserByEmail(user.Email));
            if (existUser.Success)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.UnsuccedUpdate);
        }

        /*
         Business Rules
         */


        /// <summary>
        /// Check user via Email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private IResult CheckExistUserByEmail(string email)
        {
            var existUser = _userDal.Get(x=>x.Email == email);
            if (existUser != null)
            {
                return new ErrorResult(Messages.UserMassages.UserAlreadyExist);
            }
            return new SuccessResult(null);
        }

        

    }
}
