using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetDetailsAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetailsById(carId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetDetailsBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetailsBrandId(brandId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetDetailsColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetailsColorId(colorId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarFilterBrandIdColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarFilterBrandIdColorId(brandId,colorId), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_CarDal.Get(c => c.Id == Id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.BrandId == brandId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.ColorId == colorId), Messages.CarListed);
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                return new ErrorResult();
            }

            _CarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}