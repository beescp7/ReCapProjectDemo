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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           
            _brandDal.Add(brand);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNotDeleted);
            }
            _brandDal.Add(brand);

            return new SuccessResult(Messages.CarDeleted);
        }

        
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintemamceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.CarsListed);
        }

   

        public IResult Update(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNotUpdated);
            }
            _brandDal.Update(brand);

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
