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
    public class CustomersManager : ICustomersServise
    {
        ICustomersDal _customersDal;

        public CustomersManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customers)
        {
         
            _customersDal.Add(customers);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Customer customers)
        {
            if (customers.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CarNotAdded);
            }
            _customersDal.Delete(customers);

            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Customer>> GetAll()
        {

            _customersDal.GetAll();

            return new SuccessDataResult<List<Customer>>(Messages.CarAdded);
        }

        public IResult Update(Customer customers)
        {
            if (customers.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CarNotAdded);
            }
            _customersDal.Update(customers);

            return new SuccessResult(Messages.CarAdded);
        }
    }
}
