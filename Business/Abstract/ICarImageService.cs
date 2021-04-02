using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>>  GetCarImages(int carId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int imageId);
        IResult Add(IFormFile file, CarImage image);
        IResult Update(IFormFile file,CarImage image);
        IResult Delete(CarImage image);
    }
}
