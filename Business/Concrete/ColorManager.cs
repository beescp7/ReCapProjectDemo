using Business.Absract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNotDeleted);
            }
            _colorDal.Add(color);

            return new SuccessResult(Messages.CarDeleted);
        }


        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintemamceTime);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.CarsListed);
        }



        public IResult Update(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNotUpdated);
            }
            _colorDal.Update(color);

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
