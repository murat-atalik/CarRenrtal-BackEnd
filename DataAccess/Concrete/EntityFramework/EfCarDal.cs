using Core.DataAccess.IEntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyCarDbContext>, ICarDal
    {

        List<CarDetailDto> ICarDal.GetAllCarDetails()
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var result = from c in context.Cars
                              join b in context.Brands
                              on c.BrandId equals b.BrandId
                              join clr in context.Colors
                              on c.ColorId equals clr.ColorId
                              select new CarDetailDto
                              {
                                  CarId = c.CarId,
                                  CarName = c.CarName,
                                  BrandName = b.BrandName,
                                  ColorName = clr.ColorName,
                                  DailyPrice = c.DailyPrice
                              };
                return result.ToList();
            }
        }
    }
}

