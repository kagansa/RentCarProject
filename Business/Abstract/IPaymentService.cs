using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult CardPaymentAdd(CardPayment card);
    }
}