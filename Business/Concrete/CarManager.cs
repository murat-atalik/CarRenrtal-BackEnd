using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        public void Add(Car car)
        {
            if (car.Description.Length>=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi:" + car.Description);
            }
            else if (car.Description.Length >= 2)
            {
                Console.WriteLine("Araç eklenemedi. Günlük kira bedeli 0 olamaz.");
            }
            else if (car.DailyPrice > 0)
            {
                Console.WriteLine("Araç eklenemedi. Açıklama bölümü en az 2 karaktere sahip olmalıdır.");
            }
            else
            {
                Console.WriteLine("Araç eklenemedi. Açıklama bölümü 2 karakterden az ve günlük kira bedeli 0 olamaz"); 
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç silindi:" + car.Description);
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetAllById(int carId)
        {
            return _carDal.Get(p=>p.CarId==carId);
        }

        public void Update(Car carUpdate)
        {
            _carDal.Update(carUpdate);
            Console.WriteLine("Araç güncellendi:" + carUpdate.Description);
        }
    }
}
