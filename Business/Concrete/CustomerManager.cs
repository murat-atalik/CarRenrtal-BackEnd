using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserService _userService;

        public CustomerManager(ICustomerDal customerDal,IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfUserIdExists(customer.UserId),
                CheckUniqeUser(customer.UserId));
            if (result!=null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);

        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId), Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails()
        {
           return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetAllCustomerDetails(), Messages.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfUserIdExists(customer.UserId),
               CheckUniqeUser(customer.UserId));
            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        private IResult CheckUniqeUser(int userId)
        {
            var result = _customerDal.GetAll().Where(c=>c.UserId == userId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CustomerMustUniqe);
            }
            return new SuccessResult();

        }

        private IResult CheckIfUserIdExists(int userId)
        {
            var result = _userService.GetById(userId).Data;
            if (result== null)
            {
                return new ErrorResult(Messages.UserIdNotExist);
            }
            return new SuccessResult();
        }
    }
}
