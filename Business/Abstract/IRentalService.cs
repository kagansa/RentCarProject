using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<List<RentalDetailDto>> GetDetailsAll();

        IDataResult<Rental> GetById(int Id);

        IResult Add(Rental rental);

        IResult RentalCarControl(int CarId);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);
    }
}