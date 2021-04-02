using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard card);
        IResult Payment(CreditCard card);
        IDataResult<CreditCard> GetByUserId(int id);
        IDataResult<List<CreditCard>> GetAll(int userId);
    }
}