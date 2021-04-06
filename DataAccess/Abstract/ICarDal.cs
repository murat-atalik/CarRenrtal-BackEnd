using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
       List<CarDetailDto> GetAllCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
       CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter);
    }
}
