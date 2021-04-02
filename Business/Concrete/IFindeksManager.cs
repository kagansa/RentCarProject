using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        private ICustomerService _customerService;
        private ICarService _carService;

        public FindeksManager(ICustomerService customerService, ICarService carService)
        {
            _customerService = customerService;
            _carService = carService;
        }

        public IResult Query(int carId, int customerId)
        {
            int carScore = _carService.GetById(carId).Data.MinFindeksScore;
            int customerScore = _customerService.GetById(customerId).Data.FindeksScore;
            if (carScore > customerScore)
            {
                return new ErrorResult(Messages.FindeksError);
            }
            return new SuccessResult(Messages.FindeksSuccess);
        }
    }
}