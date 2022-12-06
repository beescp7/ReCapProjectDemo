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
    public class UsersManager : IUsersServise
    {
        IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User users)
        {
            if (users.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UserNotAded);
            }
            else
            {

                _usersDal.Add(users);
                return new SuccessResult(Messages.UserAdded);
                
            }
            
        }

        public IResult Delete(User users)
        {
            if (users.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.CarNotAdded);
            }
            _usersDal.Delete(users);

            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<User>> GetAll()
        {

            //return new SuccessDataResult<List<Car>>(_cardal.GetAll(), Messages.CarsListed);
           

            return new SuccessDataResult<List<User>>(_usersDal.GetAll() ,Messages.CarAdded);
        }

        public IResult Update(User users)
        {
            if (users.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.CarNotAdded);
            }
            _usersDal.Update(users);

            return new SuccessResult(Messages.CarAdded);
        }
    }
}
