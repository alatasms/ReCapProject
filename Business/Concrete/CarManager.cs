using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {         
            _carDal.Add(car);
            return new SuccesResult(Messages.Added);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult(Messages.Deleted);
        }
        [SecuredOperation("product.add,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
            
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Messages.Listed);
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccesDataResult < List < Car >>(_carDal.GetAll(p => p.ColorId == id),Messages.Listed);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccesDataResult < List < Car >> (_carDal.GetAll(p => p.Id == id),Messages.Listed);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult < List <CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult(Messages.Updated);

        }
    }
}
