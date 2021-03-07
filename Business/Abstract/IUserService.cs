using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int Id);

        IResult Add(User user);

        IResult Update(User user);

        IResult Delete(User user);

        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}