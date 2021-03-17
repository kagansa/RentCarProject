using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsById(int carId);
        List<CarDetailDto> GetCarDetailsBrandId(int brandId);
        List<CarDetailDto> GetCarDetailsColorId(int colorId);
    }
}