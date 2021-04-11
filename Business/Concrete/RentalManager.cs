using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),
                GenericMessages<Rental>.ObjHandler + Messages.SListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id),GenericMessages<Rental>.ObjHandler+Messages.IsListed);
        }

        public IResult Add(Rental rental)
        {
            if (_rentalDal.GetAll(r=>r.CarId == rental.CarId && r.ReturnDate == null).Count >= 1)
            {
                return new ErrorResult(GenericMessages<Rental>.ObjHandler + Messages.NotAvailable);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(GenericMessages<Rental>.ObjHandler+Messages.IsAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(GenericMessages<Rental>.ObjHandler + Messages.IsDeleted);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(GenericMessages<Rental>.ObjHandler + Messages.IsUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r=>r.CarId == carId));
        }

        public IResult IsAvailable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r =>
                r.RentDateEnd >= result[0].RentDate &&
                r.RentDate <= result[0].RentDateEnd
            ))
            {
                return new ErrorResult(GenericMessages<Rental>.ObjHandler+Messages.NotAvailable);
            }

            return new SuccessResult();
        }
    }
}
