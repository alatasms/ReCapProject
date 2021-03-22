using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccesDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.Updated);
        }
    }
}
