using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine("\n List of all cars.");
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var carData in result.Data) 
                {
                    Console.WriteLine(carData.BrandName + carData.CarName + carData.DailyPrice);
                }
            }
            Console.WriteLine(carManager.GetAll().Message);

            Console.WriteLine("\n List of all brands.");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(brandManager.GetAll().Message);

            Console.WriteLine("\n List of all colors.");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine(colorManager.GetAll().Message);
            //rentalManager.Delete(new Rental() { Id = 1 });
            customerManager.Delete(new Customer() { Id = 2 });
            userManager.Delete(new User() { Id = 2 });



            User user = new User()
            {
                Id = 2,
                FirstName = "SecondUser",
                LastName = "LastNameOfThem",
                Email = "smt123@smtmail.com",
                Password = "1231425"
            };
            var UserAddResult = userManager.Add(user);
            Console.WriteLine(UserAddResult.Message);

            var CustomerAddResult =
                customerManager.Add(new Customer() {Id = 2, CompanyName = "Somee Logistics",UserId = 2});
            Console.WriteLine(CustomerAddResult.Message);


            var RentalResult = rentalManager.Add(new Rental()
            { Id = 2, CarId = 2, CustomerId = 1, RentDate = new DateTime(2021, 03, 11), ReturnDate= null });
            Console.WriteLine(RentalResult.Message);
            
            rentalManager.Update(new Rental() {Id = 2, CarId = 2, CustomerId = 1,RentDate = default,ReturnDate = new DateTime(2021, 03, 15)});
            var SecondRentalResult = rentalManager.Add(new Rental() {Id = 4, CarId = 2, CustomerId = 1, RentDate = new DateTime(2021, 03, 01)});
            Console.WriteLine(SecondRentalResult.Message);

            Console.WriteLine("List of Rentals");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate);
            }
            Console.WriteLine("List of Users");
            foreach (var VARIABLE in userManager.GetAll().Data)
            {
                Console.WriteLine(VARIABLE.FirstName);
            }
            Console.WriteLine("List of Customers");
            foreach (var VARIABLE in customerManager.GetAll().Data)
            {
                Console.WriteLine(VARIABLE.CompanyName);
            }
            //    foreach (Car car in carManager.GetAll())
            //    {
            //        Console.WriteLine(
            //            "Name: " + car.Description + " Daily Fee: " + car.DailyPrice + " Model Year: " + car.ModelYear);
            //    }

            //    //Console.WriteLine($"\n" + $"----Brand datas are being added to the db.----");
            //    //brandManager.Add(new Brand(){Id = 2,Name = "Volkswagen"});
            //    //brandManager.Add(new Brand(){Id = 3,Name = "Tesla"});
            //    //brandManager.Add(new Brand(){Id = 1,Name = "Mini Cooper"});
            //    //brandManager.Add(new Brand(){Id=4,Name = "Renault"});

            //    //Console.WriteLine($"\n" + $"----Color datas are being added to the db.----");
            //    //colorManager.Add(new Color(){Id = 1,Name = "White"});
            //    //colorManager.Add(new Color(){Id = 2,Name = "Gray"});
            //    //colorManager.Add(new Color(){Id = 3,Name = "Red"});

            //    //Console.WriteLine($"\n" + $"---- Addition of cars to the db.----");
            //    //carManager.Add(new Car() {BrandId = 1,ColorId = 2,DailyPrice = 190,Description = "Mini Countryman",Id = 1,ModelYear = 2018});
            //    //carManager.Add(new Car() {BrandId = 2,ColorId = 1,DailyPrice = 259,Description = "Volkswagen Golf",Id = 2,ModelYear = 2017});
            //    //carManager.Add(new Car() {BrandId = 3,ColorId = 3,DailyPrice = 299,Description = "Tesla Truck",Id = 3,ModelYear = 2019});
            //    //carManager.Add(new Car() {BrandId = 4,ColorId = 1,DailyPrice = 219,Description = "Renault Clio",Id = 4,ModelYear = 2016});

            //    //NowUnused(brandManager, carManager, colorManager);
            //}

            //private static void NowUnused(BrandManager brandManager, CarManager carManager, ColorManager colorManager)
            //{
            //    Console.WriteLine($"\n" + $"---- Removal of a car from the list. ----");
            //    carManager.Delete(new Car {Id = 5});
            //    Console.WriteLine("---- New listing after the removal. ----");
            //    foreach (Car car in carManager.GetAll())
            //    {
            //        Console.WriteLine(
            //            "Name: " + car.Description + " Daily Fee: " + car.DailyPrice + " Model Year: " + car.ModelYear);
            //    }

            //    Console.WriteLine($"\n" + $"---- Addition of a new car to the list. ----");
            //    carManager.Add(new Car()
            //        {BrandId = 2, ColorId = 1, DailyPrice = 421, Description = "Space X SN10", Id = 5, ModelYear = 2020});
            //    Console.WriteLine("---- New listing after the addition. ----");
            //    foreach (Car car in carManager.GetAll())
            //    {
            //        Console.WriteLine(
            //            "Name: " + car.Description + " Daily Fee: " + car.DailyPrice + " Model Year: " + car.ModelYear);
            //    }

            //    //carManager.Delete(new Car{BrandId = 1,ColorId = 2,DailyPrice = 190,Description = "Mini Countryman",Id = 1,ModelYear = 2018});

            //    Console.WriteLine($"\n" + $"---- Edit of car info. ----");
            //    carManager.Update(new Car
            //        {BrandId = 2, ColorId = 1, DailyPrice = 229, Description = "Volkswagen Golf", Id = 2, ModelYear = 2017});
            //    Console.WriteLine("---- New listing after the edit of car info. ----");
            //    foreach (Car car in carManager.GetAll())
            //    {
            //        Console.WriteLine(
            //            "Name: " + car.Description + " Daily Fee: " + car.DailyPrice + " Model Year: " + car.ModelYear);
            //    }

            //    Console.WriteLine("\n****GetCarsByBrandId with 2****");
            //    foreach (var VARIABLE in carManager.GetCarsByBrandId(2))
            //    {
            //        Console.WriteLine(VARIABLE.Description);
            //    }

            //    Console.WriteLine("\n****GetCarsByColorId with 1****");
            //    foreach (var car in carManager.GetCarsByColorId(1))
            //    {
            //        Console.WriteLine(car.Description);
            //    }

            //    Console.WriteLine($"\n" + $"Hatalı bilgiyle araç ekleme denemesi.");
            //    carManager.Add(new Car() {Id = 6, BrandId = 1, ColorId = 3, DailyPrice = 0, Description = "A", ModelYear = 2015});

            //    foreach (var car in carManager.GetCarDetails())
            //    {
            //        Console.WriteLine(car.CarName + "**" + car.BrandName + "**" + car.ColorName + "**" + car.DailyPrice);
            //    }

            //    Console.WriteLine("\n***Color and Brand Edit along with Removal Happens Here***" +
            //                      "\n New lists of colors and brands afterwards.");
            //    colorManager.Delete(new Color() {Id = 2});
            //    colorManager.Update(new Color() {Id = 1, Name = "Yellow"});

            //    brandManager.Delete(new Brand() {Id = 1});
            //    brandManager.Update(new Brand() {Id = 2, Name = "AUDI"});

            //    foreach (var c in colorManager.GetAll())
            //    {
            //        Console.WriteLine(c.Id + c.Name);
            //    }

            //    foreach (var b in brandManager.GetAll())
            //    {
            //        Console.WriteLine(b.Id + b.Name);
            //    }
        }
    }
}
