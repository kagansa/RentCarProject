using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetImagesByCarId(int carId);

        IDataResult<CarImage> GetById(int Id);

        IResult Add(IFormFile file, CarImage carImage);

        IResult Update(IFormFile file, CarImage carImage);

        IResult Delete(CarImage carImage);
    }
}