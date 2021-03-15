using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{BrandId = 1,ColorId = 1,DailyPrice = 190,Description = "Mini Countryman",Id = 1,ModelYear = 2018},
                new Car{BrandId = 2,ColorId = 2,DailyPrice = 259,Description = "Volkswagen Golf",Id = 2,ModelYear = 2017},
                new Car{BrandId = 3,ColorId = 3,DailyPrice = 299,Description = "Tesla Truck",Id = 3,ModelYear = 2019},
                new Car{BrandId = 4,ColorId = 3,DailyPrice = 219,Description = "Renault Clio",Id = 4,ModelYear = 2016},
            };
        }

        public List<Car> GetById(int Id)
        {
           return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        { ;
            Car carToBeUpdated = _cars.SingleOrDefault(c=>c.Id==car.Id);
            carToBeUpdated.BrandId = car.BrandId;
            carToBeUpdated.ColorId = car.ColorId;
            carToBeUpdated.DailyPrice = car.DailyPrice;
            carToBeUpdated.Description = car.Description;
            carToBeUpdated.Id = car.Id;
            carToBeUpdated.ModelYear = car.ModelYear;

        }

        public void Delete(Car car)
        {
            
            Car carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
    }
}
