using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int Id);

        IResult Add(User user);

        IDataResult<User> Update(UserForRegisterDto userUpdateDto, string password,int userId);

        IResult Delete(User user);

        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

        IResult UserUpdateExists(string email,int id);

    }
}