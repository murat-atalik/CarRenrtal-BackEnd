using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                //Car carAdd = new Car()
                //{
                //    CarId = car.CarId,
                //    BrandId = car.BrandId,
                //    ColorId = car.ColorId,
                //    ModelYear = car.ModelYear,
                //    DailyPrice = car.DailyPrice,
                //    Description = car.Description

                //};
                //context.Cars.Add(carAdd);
                //context.SaveChanges();
                var carToAdded = context.Entry(car);
                carToAdded.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                //Car carToDelete = context.Cars.Where(c=>c.CarId==car.CarId).FirstOrDefault();
                //context.Cars.Remove(carToDelete);
                //context.SaveChanges();
                var carToDelete = context.Entry(car);
                carToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                return filter == null
                 ? context.Set<Car>().ToList()
                : context.Set<Car>().Where(filter).ToList();

            }
        }

        public void Update(Car car)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                // Car _carUpdate = context.Cars.FirstOrDefault(c=>c.CarId==car.CarId);

                // _carUpdate.CarId = car.CarId;
                // _carUpdate.BrandId = car.BrandId;
                // _carUpdate.ColorId = car.ColorId;
                //_carUpdate.ModelYear = car.ModelYear;
                // _carUpdate.DailyPrice = car.DailyPrice;
                // _carUpdate.Description = car.Description;              
                // context.SaveChanges();
                var updatedCar= context.Entry(car);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

