using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult IsAvailable(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId);
    }
}
