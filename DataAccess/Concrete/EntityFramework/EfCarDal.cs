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
                        DailyPrice = ca.DailyPrice,
                        BrandName = br.Name,
                        ColorName = co.Name
                    }).ToList();
                return result.ToList();
            }
        }
    }
}