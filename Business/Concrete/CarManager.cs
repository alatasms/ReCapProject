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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                return new SuccesResult(Messages.Added);
            }
            else
            {
                Console.WriteLine("There is a problem about car's description lenght. Description is not longer than two characters");
                return new ErrorResult(Messages.NameInvalid);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult(Messages.Deleted);
        }

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
