//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccess.Concrete.InMemory
//{
//    public class InMemoryCarDal : ICarDal
//    {
//        List<Car> _car;

//        public InMemoryCarDal()
//        {
//            _car = new List<Car>
//            {
//                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear=1997, Description="beescp7" },
//                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=200,ModelYear=1996, Description="beescp6" },
//                new Car{Id=3,BrandId=3,ColorId=3,DailyPrice=300,ModelYear=1995, Description="beescp5" },
//                new Car{Id=4,BrandId=4,ColorId=4,DailyPrice=400,ModelYear=1994, Description="beescp4" },
//            };
//        }



//        public void Add(Car car)
//        {
//            _car.Add(car);
//        }

//        public void Delete(Car car)
//        {
//            Car carToDelete = _car.SingleOrDefault(p => p.Id == car.Id);
//            _car.Remove(carToDelete);
//        }

//        public List<Car> GetAll()
//        {
//            return _car;
//        }

//        public List<Car> GetById(int id)
//        {
//            return _car.Where(p => p.Id == id).ToList();
//        }

//        public void Update(Car car)
//        {
//            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
//            carToUpdate.Id = car.Id;
//            carToUpdate.BrandId = car.BrandId;
//            carToUpdate.ColorId = car.ColorId;
//            carToUpdate.DailyPrice = car.DailyPrice;
//            carToUpdate.ModelYear = car.ModelYear;
//            carToUpdate.Description = car.Description;
//        }
//    }
//}
