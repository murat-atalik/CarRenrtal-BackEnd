using Core.DataAccess.Abstract;
using Core.DataAccess.IEntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, MyCarDbContext>, ICustomerDal
    {
        List<CustomerDetailDto> ICustomerDal.GetCustomerDetails()
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId

                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 FirstName = u.Firstname,
                                 LastName = u.LastName,
                                 EmailAddress=u.EmailAddress,
                                 CompanyName=c.CompanyName
                                 
                             };
                return result.ToList();
            }
        }
    }
}
