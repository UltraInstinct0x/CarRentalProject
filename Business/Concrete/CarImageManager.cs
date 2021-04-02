using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]

        public IDataResult<List<CarImage>> GetCarImages(int carId)
        {
            IResult result = BusinessRules.Run(NullCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(image.CarId));
            if(result != null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(file);
            image.Date = System.DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }
            var formerPath = _carImageDal.Get(carImage =>carImage.Id == image.Id ).ImagePath;
            image.ImagePath = FileHelper.Update(formerPath, file);
            image.Date = System.DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
            File.Delete(image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult();
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var selectedCarImages = _carImageDal.GetAll(c => c.CarId == carId);
            if (selectedCarImages.Count >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> NullCarImage(int id)
        {
            try
            {
                string path = @"\wwwroot\images\default.jpg";
                var result = _carImageDal.GetAll(i => i.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> images = new List<CarImage>();
                    images.Add(new CarImage(){CarId = id,Date = DateTime.Now,ImagePath = path});
                    return new SuccessDataResult<List<CarImage>>(images);
                }

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarImage>>(e.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id));
        }
    }
}
