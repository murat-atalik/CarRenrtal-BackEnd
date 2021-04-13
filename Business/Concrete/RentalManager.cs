using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal,ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(rental.CarId), 
                CheckIfCarReturn(rental.CarId));

            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);


        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==rentalId),Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(),Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(rental.CarId), CheckIfCarExists(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult CheckIfCarReturn(int carId)
        {

            var result = _rentalDal.GetAll().Where(r => r.CarId == carId).ToList();

            if (result.Count==0)
            {
                return new SuccessResult();
            }

            else if (result.FirstOrDefault(r=>r.ReturnDate!=null)!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotReturn);
        }
        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId).Data;
            if (result==null)
            {
                return new ErrorResult(Messages.CarNotExists);
            }
            return new SuccessResult();

        }
    }
}
