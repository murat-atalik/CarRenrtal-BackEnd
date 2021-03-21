using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarOperations();

            //ColorOperations();

            // BrandOperations();

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(" Car ID:" + car.CarId + " Name: " + car.CarName + " Model " + car.BrandName + " Renk: " + car.ColorName + " Günlük kira: " + car.DailyPrice);
            }


        }

        private static void BrandOperations()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand()
            {
                BrandId = 13,
                BrandName = "Jeep"
            };
            Brand brand2 = new Brand()
            {
                BrandId = 13,
                BrandName = "Chevrolet"
            };
            Brand brand3 = new Brand()
            {
                BrandId = 10,
                BrandName = "Ford"
            };
            Console.WriteLine("---- Add brand ----");
            brandManager.Add(brand1);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            Console.WriteLine("---- Delete brand ----");
            brandManager.Delete(brand2);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            Console.WriteLine("---- Update brand ----");
            brandManager.Update(brand3);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            Brand brandId = brandManager.GetById(7).Data;
            Console.WriteLine(brandId.BrandId + " " + brandId.BrandName);
        }

        private static void ColorOperations()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color()
            {
                ColorName = "Deneme"
            };
            Color color2 = new Color()
            {
                ColorId = 13,
                ColorName = "Kahverengi"
            };
            Color color3 = new Color()
            {
                ColorId = 10,
                ColorName = "Gümüş"
            };
            Console.WriteLine("-----Add Operation-----");
            colorManager.Add(color1);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
            Console.WriteLine("-----Delete Operation-----");
            //colorManager.Delete(color2);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
            Console.WriteLine("-----Update Operation-----");
            colorManager.Update(color3);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
            Console.WriteLine(colorManager.GetById(1).Data.ColorId + " " + colorManager.GetById(1).Data.ColorName);
        }

        private static void CarOperations()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car()
            {
                
                BrandId = 1,
                ColorId = 1,
                CarName="SLX",
                ModelYear = 2077,
                DailyPrice = 1,
                Description = "cy"

            };
            carManager.Add(car1);                                                                       //Worked 101.Eleman eklendi
            carManager.Update(car1);                                                                     //Worked 99 ve 100. elemanlar güncellendi
            carManager.Delete(car1);                                                                      //Worked 98. eleman silindi
            foreach (var car in carManager.GetAll().Data)                                                      //Worked tüm elemanlar çağırldı
            {
                Console.WriteLine(car.CarId + " " + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine(carManager.GetById(101).Data.CarId + carManager.GetById(101).Data.Description);  //Worked GetById
        }
    }
}
