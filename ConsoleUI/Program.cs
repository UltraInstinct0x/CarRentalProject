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
            Console.WriteLine($"\n" + $"---- Listing of all existing cars. ----");
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Console.WriteLine($"\n" + $"----Brand datas are being added to the db.----");
            //brandManager.Add(new Brand(){Id = 2,Name = "Volkswagen"});
            //brandManager.Add(new Brand(){Id = 3,Name = "Tesla"});
            //brandManager.Add(new Brand(){Id = 1,Name = "Mini Cooper"});
            //brandManager.Add(new Brand(){Id=4,Name = "Renault"});

            //Console.WriteLine($"\n" + $"----Color datas are being added to the db.----");
            //colorManager.Add(new Color(){Id = 1,Name = "White"});
            //colorManager.Add(new Color(){Id = 2,Name = "Gray"});
            //colorManager.Add(new Color(){Id = 3,Name = "Red"});

            //Console.WriteLine($"\n" + $"---- Addition of cars to the db.----");
            //carManager.Add(new Car() {BrandId = 1,ColorId = 2,DailyPrice = 190,Description = "Mini Countryman",Id = 1,ModelYear = 2018});
            //carManager.Add(new Car() {BrandId = 2,ColorId = 1,DailyPrice = 259,Description = "Volkswagen Golf",Id = 2,ModelYear = 2017});
            //carManager.Add(new Car() {BrandId = 3,ColorId = 3,DailyPrice = 299,Description = "Tesla Truck",Id = 3,ModelYear = 2019});
            //carManager.Add(new Car() {BrandId = 4,ColorId = 1,DailyPrice = 219,Description = "Renault Clio",Id = 4,ModelYear = 2016});

            Console.WriteLine("\n List of all brands.");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("\n List of all cars.");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine("\n List of all colors.");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine($"\n" + $"---- Addition of a new car to the list. ----");
            //carManager.Add(new Car() { BrandId = 3, ColorId = 3, DailyPrice = 400, Description = "Tesla Model T", Id = 5, ModelYear = 2018 });
            Console.WriteLine("---- New listing after the addition. ----");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine($"\n" + $"---- Removal of a car from the list. ----");
            //carManager.Delete(new Car{BrandId = 1,ColorId = 2,DailyPrice = 190,Description = "Mini Countryman",Id = 1,ModelYear = 2018});
            Console.WriteLine("---- New listing after the removal. ----");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine($"\n" + $"---- Edit of car info. ----");
            //carManager.Update(new Car{BrandId = 2,ColorId = 1,DailyPrice = 229,Description = "Volkswagen Polo",Id = 2,ModelYear = 2017});
            Console.WriteLine("---- New listing after the edit of car info. ----");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine("\n****GetCarsByBrandId with 3****");
            foreach (var VARIABLE in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(VARIABLE.Description);
            }

            Console.WriteLine("\n****GetCarsByColorId with 1****");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine($"\n" + $"Hatalı bilgiyle araç ekleme denemesi.");
            carManager.Add(new Car(){Id = 6,BrandId = 1,ColorId = 3,DailyPrice = 0,Description = "A",ModelYear = 2015});
        }
    }
}
