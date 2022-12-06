using Business.Absract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _cardal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNotDeleted);
            }
            _cardal.Add(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            //Yetkisi Var Mı?
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintemamceTime);
            }

            return new SuccessDataResult<List<Car>>(_cardal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<Car> GetById(int carId)
        {
             return new SuccessDataResult<Car>(_cardal.Get(p => p.Id == carId));
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintemamceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetProductDetails());
        }

        public IResult Update(Car car)
        {

            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNotUpdated);
            }
            _cardal.Add(car);

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
