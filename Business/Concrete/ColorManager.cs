using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int Id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == Id), Messages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }
    }
}