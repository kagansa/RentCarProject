using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IResult Query(int carId, int customerId);
    }
}