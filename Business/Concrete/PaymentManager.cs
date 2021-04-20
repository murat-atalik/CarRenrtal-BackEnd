using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _paymentDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult CheckPayment(CreditCard creditCard)
        {
            var result = _paymentDal.Get(c=>c.CardNumber==creditCard.CardNumber);
            if (result!=null)
            {
                result.CardBalance = result.CardBalance - creditCard.CardBalance;
                if (result.CardBalance < 0)
                {
                    return new ErrorResult("Yeterli bakiye bulunmamaktadır.");
                }
                _paymentDal.CheckPayment(result);
                return new SuccessResult();
            }
            return new ErrorResult("Kart bulunamadı");
            
        }

        public IResult Delete(CreditCard creditCard)
        {
            _paymentDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<CreditCard> GetById(string creditCardNumber)
        {
            return new SuccessDataResult<CreditCard>(_paymentDal.Get(c => c.CardNumber == creditCardNumber));
        }

        public IResult Update(CreditCard creditCard)
        {
            _paymentDal.Update(creditCard);
            return new SuccessResult();
        }
    }
}
