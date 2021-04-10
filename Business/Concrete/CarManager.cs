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
      
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

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
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(), Messages.CarsDetailsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }
        public IDataResult<CarDetailDto> GetById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.CarId == carId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrand(int brandId)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c=>c.BrandId==brandId), Messages.CarImagesListed);

        }
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByColor(int colorId)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.ColorId == colorId), Messages.CarImagesListed);
        }


    }
}

