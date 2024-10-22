﻿using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), GenericMessages<Car>.ObjHandler + Messages.SListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id).ToList());
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id).ToList());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId));
        }

        //[SecuredOperation("admin,car.add")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(GenericMessages<Car>.ObjHandler + Messages.IsAdded);
            }
            else
            {
                return new ErrorResult(GenericMessages<Car>.ObjHandler + Messages.NameInvalid + "\n" + Messages.CarPriceInvalid);
            }
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(GenericMessages<Car>.ObjHandler + Messages.IsDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(GenericMessages<Car>.ObjHandler + Messages.IsUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string name)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == name));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brand, string color)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
                c.BrandName == brand && c.ColorName == color));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string name)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == name));
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }
    }
}
