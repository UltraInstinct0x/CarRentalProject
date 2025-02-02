﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
      public class FakeFindeksManager : IFindeksService
    {
        private readonly IFindeksDal _findeksDal;

        public FakeFindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }
        public IDataResult<Findeks> CalculateFindeksScore(Findeks findeks)
        {
            findeks.Score = (short) new Random().Next(0, 1901);

            return new SuccessDataResult<Findeks>(findeks);
        }

        public IDataResult<Findeks> GetById(int id)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.Id == id));
        }

        public IDataResult<Findeks> GetByCustomerId(int customerId)
        {
            var findeks = _findeksDal.Get(f => f.CustomerId == customerId);
            if (findeks == null) return new ErrorDataResult<Findeks>(Messages.FindeksNotFound);

            return new SuccessDataResult<Findeks>(findeks);
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IResult Add(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            _findeksDal.Add(newFindeks);

            return new SuccessResult();
        }

        public IResult Update(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            _findeksDal.Update(newFindeks);

            return new SuccessResult();
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);

            return new SuccessResult();
        }
    }
}
