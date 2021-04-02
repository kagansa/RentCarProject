using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard card)
        {
            
            _creditCardDal.Add(card);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Payment(CreditCard card)
        {
            if (!card.Number.StartsWith("0")) return new ErrorResult(Messages.PaymentError);
            return new SuccessResult(Messages.PaymentSuccess);
        }

        public IDataResult<CreditCard> GetByUserId(int userId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == userId));
        }

        public IDataResult<List<CreditCard>> GetAll(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(x=> x.UserId==userId), Messages.CustomerListed);

            //var result = _creditCardDal.GetAll(x => x.UserId == userId);
            //if (result != null)
            //{
            //    return new SuccessDataResult<List<CreditCard>>(result, Messages.CustomerListed);
            //}

            //return new ErrorDataResult<List<CreditCard>>("hata");
        }
    }
}