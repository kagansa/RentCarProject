using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = 
                    (from re in context.Rentals
                    join ca in context.Cars on re.CarId equals ca.Id
                    join cu in context.Customers on re.CustomerId equals cu.Id
                    join br in context.Brands on ca.BrandId equals br.Id
                    join us in context.Users on cu.UserId equals us.Id
                    select new RentalDetailDto
                    {
                        RentalId = re.Id,
                        CarId = ca.Id,
                        BrandName = br.Name,
                        CarName = ca.Description,
                        CustomerId = cu.Id,
                        FirstName = us.FirstName,
                        LastName = us.LastName,
                        RentDate = re.RentDate,
                        ReturnDate = re.ReturnDate
                    }).ToList();
                return result.ToList();
            }
        }
    }
}