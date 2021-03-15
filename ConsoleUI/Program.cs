using System;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Listing of all existing cars. ----");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine($"\n" + $"---- Addition of new car to the list. ----");
            carManager.Add(new Car(){BrandId = 5,ColorId = 3,DailyPrice=400,Description = "Tesla Model T", Id = 5,ModelYear = 2018});
            Console.WriteLine("---- New listing after the addition. ----");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine("\n ---- Selection of a car by its id. ----");
            foreach (Car car in carManager.GetById(2))
            {
                Console.WriteLine("Seçilen Araç: " + car.Description);
            }

            Console.WriteLine($"\n" + $"---- Removal of a car from the list. ----");
            carManager.Delete(new Car{BrandId = 1,ColorId = 1,DailyPrice = 190,Description = "Mini Countryman",Id = 1,ModelYear = 2018});
            Console.WriteLine("---- New listing after the removal. ----");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }

            Console.WriteLine($"\n" + $"---- Edit of car info. ----");
            carManager.Update(new Car{BrandId = 2,ColorId = 3,DailyPrice = 229,Description = "Volkswagen Polo",Id = 2,ModelYear = 2017});
            Console.WriteLine("---- New listing after the edit of car info. ----");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Name: "+car.Description +" Daily Fee: " +car.DailyPrice +" Model Year: " + car.ModelYear);
            }
        }
    }
}
