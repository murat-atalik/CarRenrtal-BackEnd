using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager:ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {

            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.CarImageId == carImage.CarImageId).ImagePath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int CarImageId)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(CarImageId));
            if (result!=null)
            {
                return new ErrorDataResult<CarImage>(result.Message);
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == CarImageId));
        }


        public IDataResult<List<CarImage>> GetAllCarImages(int Id)
        {
          //  IResult carResult = BusinessRules.Run(CheckIfCarExists(Id));
            IResult imageResult = BusinessRules.Run(CheckIfCarImageImageCountNull(Id));
            
            //if (carResult != null)
            //{
                   
            //        return new ErrorDataResult<List<CarImage>>(carResult.Message);
                
            //}

            if (imageResult != null)
            {
                string path = @"\Images\DefaultImage.png";
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = Id, ImagePath = path, ImageDate = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImage, Messages.CarImageDefault);

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == Id),Messages.CarImagesListed);
        }


       

        private IResult CheckIfImageLimitExceded(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageImageCountNull(int carId)
        {
            
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.CarImageDefault);
            }
        
            return new SuccessDataResult<List<CarImage>>();
        }
        //private IResult CheckIfCarExists(int carId)
        //{
        //    var result = _carService.GetById(carId).Data;
        //    if (result==null)
        //    {
        //        return new ErrorResult(Messages.CarNotExists);
        //    }
        //    return new SuccessResult();
        //}
        private IDataResult<CarImage> CheckIfImageExists(int imageId)
        {
            var result = _carImageDal.Get(c=>c.CarImageId==imageId);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.ImageNotExists);
            }
            return new SuccessDataResult<CarImage>();
        }

    }
}



