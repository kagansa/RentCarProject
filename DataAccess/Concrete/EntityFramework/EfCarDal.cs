using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = (from ca in context.Cars
                              join co in context.Colors on ca.ColorId equals co.Id
                              join br in context.Brands on ca.BrandId equals br.Id
                              select new CarDetailDto
                              {
                                  CarId = ca.Id,
                                  CarName = ca.Description,
                                  BrandId = br.Id,
                                  DailyPrice = ca.DailyPrice,
                                  BrandName = br.Name,
                                  ColorId = co.Id,
                                  ColorName = co.Name,
                                  ModelYear = ca.ModelYear
                              }).ToList();
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = (from ca in context.Cars
                    join co in context.Colors on ca.ColorId equals co.Id
                    join br in context.Brands on ca.BrandId equals br.Id
                    where ca.Id == carId
                              select new CarDetailDto
                    {
                        CarId = ca.Id,
                        CarName = ca.Description,
                        BrandId = br.Id,
                        DailyPrice = ca.DailyPrice,
                        BrandName = br.Name,
                        ColorId = co.Id,
                        ColorName = co.Name,
                        ModelYear = ca.ModelYear
                    }).ToList();
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsBrandId(int brandId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = (from ca in context.Cars
                              join co in context.Colors on ca.ColorId equals co.Id
                              join br in context.Brands on ca.BrandId equals br.Id
                              where ca.BrandId == brandId
                              select new CarDetailDto
                              {
                                  CarId = ca.Id,
                                  CarName = ca.Description,
                                  BrandId = br.Id,
                                  DailyPrice = ca.DailyPrice,
                                  BrandName = br.Name,
                                  ColorId = co.Id,
                                  ColorName = co.Name,
                                  ModelYear = ca.ModelYear
                              }).ToList();
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsColorId(int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = (from ca in context.Cars
                              join co in context.Colors on ca.ColorId equals co.Id
                              join br in context.Brands on ca.BrandId equals br.Id
                              where ca.ColorId == colorId
                              select new CarDetailDto
                              {
                                  CarId = ca.Id,
                                  CarName = ca.Description,
                                  BrandId = br.Id,
                                  DailyPrice = ca.DailyPrice,
                                  BrandName = br.Name,
                                  ColorId = co.Id,
                                  ColorName = co.Name,
                                  ModelYear = ca.ModelYear
                              }).ToList();
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarFilterBrandIdColorId(int brandId, int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = (from ca in context.Cars
                    join co in context.Colors on ca.ColorId equals co.Id
                    join br in context.Brands on ca.BrandId equals br.Id
                    where ca.ColorId == colorId && br.Id == brandId
                    select new CarDetailDto
                    {
                        CarId = ca.Id,
                        CarName = ca.Description,
                        BrandId = br.Id,
                        DailyPrice = ca.DailyPrice,
                        BrandName = br.Name,
                        ColorId = co.Id,
                        ColorName = co.Name,
                        ModelYear = ca.ModelYear
                    }).ToList();
                return result.ToList();
            }
        }
    }
}