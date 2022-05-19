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
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var IsExistValidation = BusinessRulesValidator.Run(_authBusinessRules.CheckUserExist(userForRegisterDto.Email));

            if (IsExistValidation == null)
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
                    Status = true,
                    FindexPoint = 1500
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user , true, Messages.AuthMessages.SucceedUserRegistiration);
            }
            return new ErrorDataResult<User>(IsExistValidation.Message);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var isUserExist = _authBusinessRules.CheckUserExistForLogin(userForLoginDto.Email);

            if (isUserExist.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserMassages.UserNotFound);
            }
              
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, isUserExist.Data.PasswordHash, isUserExist.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.AuthMessages.RegistirationDenied);
            }
            return new SuccessDataResult<User>(isUserExist.Data, true, Messages.AuthMessages.SuccessLogin);
        }
              
              




    




        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, true, Messages.AuthMessages.AccessTokenCreated);
        }
    }
}
