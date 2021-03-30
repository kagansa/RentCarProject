using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailDto>> GetDetailsAll();

        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);

        IDataResult<List<CarDetailDto>> GetDetailsBrandId(int brandId);

        IDataResult<List<CarDetailDto>> GetDetailsColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarFilterBrandIdColorId(int brandId,int colorId);

        IDataResult<Car> GetById(int id);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);
    }
}