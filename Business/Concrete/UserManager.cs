using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService

    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEmailAddressExists(user.EmailAddress));

            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), Messages.UserListed);
        }

        [ValidationAspect(typeof(User))]
        public IResult Update(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEmailAddressExists(user.EmailAddress));

            if (result!=null)
            {
                return result;
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        private IResult CheckIfEmailAddressExists(string emailAddress)
        {
            var result = _userDal.GetAll().Where(u=>u.EmailAddress==emailAddress);
            if (result!=null)
            {
                return new ErrorResult(Messages.EmailAlreadyExists);
            }
            return new SuccessResult();
        }

      
    }
}
