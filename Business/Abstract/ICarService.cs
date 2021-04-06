using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<CarDetailDto> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByColor(int colorId);
    }
}
