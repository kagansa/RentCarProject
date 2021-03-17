using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImage)
        {
            _carImageDal = carImage;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var results = _carImageDal.GetAll(c => c.CarId == carId);
            if (results == null)
            {
                CarImage defaultImage = new CarImage { CarId = carId, ImagePath = "rental.jpg" };
                results.Add(defaultImage);
            }
            return new SuccessDataResult<List<CarImage>>(results, Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id), Messages.CarImageListed);
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = CheckCarImageCountLimit(carImage, 5);
            if (!result.Success) return new ErrorResult(result.Message);

            carImage.ImagePath = FileHelper.AddCarImage(file);
            if (carImage.ImagePath == null) return new ErrorResult();

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage = _carImageDal.Get(c => c.Id == carImage.Id);
            carImage.ImagePath = FileHelper.UpdateCarImage(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(int imgId)
        {
            CarImage carImage = _carImageDal.Get(c => c.Id == imgId);
            FileHelper.DeleteCarImage(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckCarImageCountLimit(CarImage carImage, int maxCountOfImages)
        {
            var imageCount = _carImageDal.GetAll(ci => ci.CarId == carImage.CarId).Count;

            if (imageCount >= maxCountOfImages)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}