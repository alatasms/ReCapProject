using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult();

        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult();
        }
    }
}
