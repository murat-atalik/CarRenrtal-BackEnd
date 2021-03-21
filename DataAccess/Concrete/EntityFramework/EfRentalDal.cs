using Core.DataAccess.IEntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyCarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.Id
                             join cr in context.Cars
                             on r.CarId equals cr.CarId
                             join clr in context.Colors
                             on cr.ColorId equals clr.ColorId
                             join b in context.Brands
                             on cr.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerFirstName = u.Firstname,
                                 CustomerLastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 EmailAddress = u.EmailAddress,
                                 CarName = cr.CarName,
                                 CarBrand = b.BrandName,
                                 CarColor = clr.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();

            }
        }
    }
}