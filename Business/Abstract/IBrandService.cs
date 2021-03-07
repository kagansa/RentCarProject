using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();

        IDataResult<Brand> GetById(int Id);

        IResult Add(Brand brand);

        IResult Update(Brand brand);

        IResult Delete(Brand brand);
    }
}