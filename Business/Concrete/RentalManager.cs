using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        IPaymentService _paymentService;

        public RentalManager(IRentalDal rentalDal,ICarService carService,IPaymentService paymentService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _paymentService = paymentService;
        }

        [ValidationAspect(typeof(RentalValidator))]

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(rental.CarId), 
                CheckIfCarReturn(rental));

            if (result!=null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==rentalId),Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(),Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(rental.CarId), CheckIfCarExists(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult CheckIfCarReturn(Rental rental)
        {

            var result = _rentalDal.GetAll().Where(r => r.CarId == rental.CarId).LastOrDefault();
            if (result!=null) { var a = (rental.RentDate - result.ReturnDate).GetValueOrDefault();
                if (a.TotalSeconds > 0)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.CarNotReturn);
            }else { return new SuccessResult(); }

        }

        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId).Data;
            if (result==null)
            {
                return new ErrorResult(Messages.CarNotExists);
            }
            return new SuccessResult();

        }

        [TransactionScopeAspect]
        public IResult PaymetTransaction(PaymentDto[] paymentDtos)
        {
            foreach (PaymentDto paymentDto in paymentDtos)
            {
                CreditCard creditCard = new CreditCard { CardNumber = paymentDto.CardNumber, CardBalance = paymentDto.CardBalance, FullName = paymentDto.FullName, ValidDate = paymentDto.ValidDate,Cvv=paymentDto.Cvv };
                Rental rental = new Rental { CarId = paymentDto.CarId, CustomerId = paymentDto.CustomerId, RentDate = paymentDto.RentDate, ReturnDate = paymentDto.ReturnDate };

                var paymentResult = _paymentService.CheckPayment(creditCard);
                if (!paymentResult.Success)
                {
                    throw new Exception(paymentResult.Message);
                }
                var addResult = Add(rental);
                if (!addResult.Success)
                {
                    throw new Exception(addResult.Message);
                }

            }

            return new SuccessResult(Messages.CarAdded);
        }
    }
}
