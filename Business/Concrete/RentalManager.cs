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
    public class RentalManager : IRentalsServise
    {
        IRentalsDal _rentalsDal;

        public RentalManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rentals)
        {
            _rentalsDal.Add(rentals);

            return new SuccessResult(Messages.RentalInvalid);

        }

        public IResult Delete(Rental rentals)
        {

            _rentalsDal.Delete(rentals);

            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.CarAdded);
        }

        public IResult Update(Rental rentals)
        {

            _rentalsDal.Update(rentals);

            return new SuccessResult(Messages.CarAdded);
        }
    }
}
