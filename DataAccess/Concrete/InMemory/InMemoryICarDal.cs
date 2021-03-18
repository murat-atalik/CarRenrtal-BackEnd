using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryICarDal : ICarDal
    {
        List<Car> _cars;

        //Fake DB
        public InMemoryICarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=900,ModelYear=2015,Description="Suv"},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=2000,ModelYear=2015,Description="Sport"},
                new Car{CarId=3,BrandId=2,ColorId=2,DailyPrice=800,ModelYear=2020,Description="Elektrikli"},
                new Car{CarId=4,BrandId=3,ColorId=1,DailyPrice=1000,ModelYear=1969,Description="clasic"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car carUpdate)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == carUpdate.CarId);
            carToUpdate.BrandId = carUpdate.BrandId;
            carToUpdate.ColorId = carUpdate.ColorId;
            carToUpdate.DailyPrice = carUpdate.DailyPrice;
            carToUpdate.Description = carUpdate.Description;
            carToUpdate.ModelYear = carUpdate.ModelYear;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

    }
}