using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Business.ValidationRules.BusinessRules.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Helper.HashingHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAuthBusinessRules _authBusinessRules;
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IAuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var IsExistValidation = BusinessRulesValidator.Run(_authBusinessRules.CheckUserExist(userForRegisterDto.Email));

            if (!IsExistValidation.Success)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(Messages.AuthMessages.SucceedUserRegistiration)
            }
            return new ErrorDataResult<User>(IsExistValidation.Message);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var isUserExist = BusinessRulesValidator.Run(_authBusinessRules.CheckUserExist(userForLoginDto.Email));
            
            if (!isUserExist.Success)
            {
                return new ErrorDataResult<User>(Messages.UserMassages.UserNotFound);
            }

            var userData = _userService.GetByEmail(userForLoginDto.Email); 
            

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userData.Data.PasswordHash, userData.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.AuthMessages.RegistirationDenied);
            }

            return new SuccessDataResult<User>(userData.Data, true, Messages.AuthMessages.SuccessLogin);
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, true, Messages.AuthMessages.AccessTokenCreated);
        }
    }
}
