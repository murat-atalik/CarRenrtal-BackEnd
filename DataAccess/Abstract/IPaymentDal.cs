using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPaymentDal:IEntityRepository<CreditCard>
    {
      void CheckPayment(CreditCard creditCard);
    }
}
