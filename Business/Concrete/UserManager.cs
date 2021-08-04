using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspects("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult(Messages.Added);
        }

        [CacheRemoveAspects("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult(Messages.Deleted);

        }
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(),Messages.Listed);
        }

        public IDataResult<User> GetByEmail(string email)
        {

            return new SuccesDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccesDataResult<List<OperationClaim>>(_userDal.GetClaims(user));

        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspects("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult(Messages.Updated);
        }
    }
}
