using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<CreditCard> GetById(string creditCardNumber);
        IResult CheckPayment(CreditCard creditCard);
    }
}
