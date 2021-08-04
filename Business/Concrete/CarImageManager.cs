using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspects("ICarImageService.Get")]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.LimitExceded);
            }
            var imageResult = FileHelper.Add(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccesResult(Messages.Added);
        }

        [CacheRemoveAspects("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(p => p.Id == carImage.Id);
            if (image==null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccesDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data,Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspects("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(p => p.Id == carImage.Id);
            if (image==null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            var updatedFile = FileHelper.Update(file, image.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccesResult(Messages.Updated);
        }

        private IResult CheckIfImageLimitExceded(int CarId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == CarId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.LimitExceded);
            }
            return new SuccesResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int Id)
        {
            try
            {
                string path = @"/images/logo.png";
                var result = _carImageDal.GetAll(p => p.CarId == Id).Any();
                if (!result)
                {
                    List<CarImage> carImages = new List<CarImage>();
                    carImages.Add(new CarImage { CarId = Id, ImagePath = path, Date = DateTime.Now });
                    return new SuccesDataResult<List<CarImage>>(carImages.ToList());
                }

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == Id).ToList());
        }
    }
}
