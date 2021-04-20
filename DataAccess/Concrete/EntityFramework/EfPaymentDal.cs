using Core.DataAccess.IEntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<CreditCard, MyCarDbContext>, IPaymentDal
    {
        public void CheckPayment(CreditCard creditCard)
        {
            using(MyCarDbContext context=new MyCarDbContext())
            {
                var updateCardBalance = context.Entry(creditCard);
                updateCardBalance.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
