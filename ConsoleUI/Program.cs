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
            //CRUD Operations
            //CarOperations();

            //ColorOperations();

            //BrandOperations();

            //UserOperations();

            //CustomersOperations();

            //Dto Operations
            //CarDetails();
            //CustomerDetails();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental()
            {
                CarId = 4,
                CustomerId = 4,
                RentDate = new DateTime(2021, 3, 21)
            };

            rentalManager.Add(rental1);
            //Console.WriteLine(rentalManager.Add(rental1).Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + " " + rental.CarId + " " + rental.CustomerId + " " + rental.RentDate + " " + rental.ReturnDate);
            }

            ////rentalManager.Delete(rental2);
            //foreach (var rental in rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine(rental.Id + " " + rental.CustomerId + " " + rental.RentDate + " " + rental.ReturnDate);
            //}
            ////rentalManager.Update(rental2);
            //foreach (var rental in rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine(rental.Id + " " + rental.CustomerId + " " + rental.RentDate + " " + rental.ReturnDate);
            //}
            //Console.WriteLine(" ----------------");
            //Console.WriteLine(rentalManager.GetById(3).Data.RentDate);
            //Console.WriteLine("--------------------------------------");
            //foreach (var rental in rentalManager.GetAllRentalDetails().Data)
            //{
            //    Console.WriteLine(rental.CarName + " " + rental.CarColor + "  " + rental.CarBrand + " " + rental.CompanyName + "   " + rental.CustomerFirstName + "  " + rental.CustomerLastName + "  " + rental.EmailAddress + "  " + rental.DailyPrice + " " + rental.RentDate + " " + rental.ReturnDate);
            //}
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //foreach (var item in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(item.CustomerId + " UserId: " + item.UserId + " CN:" + item.CompanyName);
            //}
            //Customer customer1 = new Customer()
            //{CustomerId=2013,
            //    UserId = 3,
            //    CompanyName = "Vesely airlines"

            //}; Customer customer2 = new Customer()
            //{CustomerId=2015,
            //    UserId = 1004,
            //    CompanyName = "Vesely airlines"

            //};
            //customerManager.Update(customer1);
            // customerManager.Delete(customer2);

        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAllCarDetails().Data)
            {
                Console.WriteLine(" Car ID:" + car.CarId + " Name: " + car.CarName + " Model " + car.BrandName + " Renk: " + car.ColorName + " Günlük kira: " + car.DailyPrice);
            }
        }

        private static void CustomerDetails()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAllCustomerDetails().Data)
            {
                Console.WriteLine(" Customer ID:" + customer.CustomerId + " Name: " + customer.FirstName + " Surname: " + customer.LastName + " CompanyName " + customer.CompanyName + " Email adress: " + customer.EmailAddress);
            }
        }

        private static void CustomersOperations()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer()
            {
                UserId = 9,
                CompanyName = "Vesely airlines"

            };
            Customer customer2 = new Customer()
            {
                CustomerId = 5

            }; Customer customer3 = new Customer()
            {
                CustomerId = 7,
                UserId = 2,
                CompanyName = "De dust"
            };
            Console.WriteLine("--- Add ---");
            customerManager.Add(customer1);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.UserId + " " + customer.CompanyName);
            }
            Console.WriteLine("--- Delete ---");
            customerManager.Delete(customer2);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.UserId + " " + customer.CompanyName);
            }
            Console.WriteLine("--- Update ---");
            customerManager.Update(customer3);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.UserId + " " + customer.CompanyName);
            }
            Console.WriteLine("--- GetId ---");
            Console.WriteLine(customerManager.GetById(6).Data.CompanyName);
        }

        private static void UserOperations()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user1 = new User()
            {
                Id = 8,

            };
            User user2 = new User()
            {
                Id = 2,
                Firstname = "igor",
                LastName = "Vasili",
                EmailAddress = "igorvasili@bisi.com",
                Password = "123324"
            }; User user3 = new User()
            {

                Firstname = "Jan",
                LastName = "Vesely",
                EmailAddress = "veselyairlines@bisi.com",
                Password = "12324354534324"
            };
            Console.WriteLine("--- Add ---");
            userManager.Add(user3);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + " " + user.Firstname + " " + user.LastName + " " + user.EmailAddress);
            }
            Console.WriteLine("--- Delete ---");
            userManager.Delete(user1);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + " " + user.Firstname + " " + user.LastName + " " + user.EmailAddress);
            }
            Console.WriteLine("--- Update ---");
            userManager.Update(user2);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + " " + user.Firstname + " " + user.LastName + " " + user.EmailAddress);
            }
            Console.WriteLine("--- GetId ---");
            Console.WriteLine(userManager.GetById(2).Data.EmailAddress);
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
            colorManager.Delete(color2);
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
                CarName = "SLX",
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
