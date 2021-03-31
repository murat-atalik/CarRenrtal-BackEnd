using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            IResult result = BusinessRules.Run(PasswordCheck(userForLoginDto.Password, userForLoginDto.Email));
            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(_userService.GetByEmail(userForLoginDto.Email).Data, Messages.UserLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {


            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash , out passwordSalt);
            var user = new User()
            {
                EmailAddress = userForRegisterDto.Email,
                Firstname = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserAdded);

        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByEmail(email);
            if (!result.Success)
            {
                return new ErrorResult(Messages.UserNotExist);
            }

            return new SuccessResult(Messages.UserExists);
        }

       

        private IResult PasswordCheck(string password, string email)
        {
            var auth = _userService.GetByEmail(email).Data;
            var result = HashingHelper.VerifyPasswordHash(password, auth.PasswordHash, auth.PasswordSalt);
            if (!result)
            {
                return new ErrorResult(Messages.WrongPassword);
            }

            return new SuccessResult();
        }

    }
}
