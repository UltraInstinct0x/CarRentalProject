using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),GenericMessages<User>.ObjHandler+Messages.SListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id),
                GenericMessages<User>.ObjHandler+Messages.IsListed);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(GenericMessages<User>.ObjHandler + Messages.IsAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(GenericMessages<User>.ObjHandler + Messages.IsDeleted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(GenericMessages<User>.ObjHandler + Messages.IsUpdated);
        }
    }
}
