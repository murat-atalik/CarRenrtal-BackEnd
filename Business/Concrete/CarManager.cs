using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Microsoft.AspNetCore.Authorization;
using Core.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }
        [Authorize(Roles = "car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [PerformanceAspect(10)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            var cars = _carDal.GetAllCarDetails();
            string path = @"\Images\DefaultImage.png";
            foreach (var car in cars)
            {
                if (car.ImagePath == null)
                {
                    car.CarImageId = 0;
                    car.ImagePath = path;
                    car.ImageDate = DateTime.Now;
                }
            }
            return new SuccessDataResult<List<CarDetailDto>>(cars, Messages.CarsDetailsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }
        public IDataResult<CarDetailDto> GetById(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(carId));

            if (result!=null)
            {
                var car = _carDal.GetCarDetails(c => c.CarId == carId);
                string path = @"\Images\DefaultImage.png";
                car.ImagePath = path;
                car.ImageDate = DateTime.Now;
                return new SuccessDataResult<CarDetailDto>(car, Messages.CarImageDefault);
            }

            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.CarId == carId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.BrandId == brandId), Messages.CarsDetailsListed);
        }
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.ColorId == colorId), Messages.CarsDetailsListed);
        }
        private IResult CheckIfImageExists(int carId)
        {
            
            var car = _carImageService.GetAllCarImages(carId).Data;
            
                if (car[0].CarImageId== 0)
                {
                    return new ErrorResult(Messages.CarImageDefault);
                }
            

            return new SuccessResult();
        }
    }


}

