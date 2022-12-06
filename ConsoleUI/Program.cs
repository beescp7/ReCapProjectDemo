using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Data;
using Business.Constants;
using Core.Utilities.Results;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
       // TestCar();
        //TestBrand();
        // TestColor();
      //   CarTest();

          TestRental();
     // TestUser();
    }
    private static void CarTest()
    {
        // Console.WriteLine("Hello, World!");
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetails();
        if (result.Success)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "   berkan  " + car.BrandName+"   "+car.ColorName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }



    }
    private static void TestRental()
    {
        Nullable<DateTime> dt=null;
        RentalManager rentalManager = new RentalManager(new EfRentalsDal());
        //var result = rentalManager.Add(new Rental { Id = 8, CarId = 3, CustomerId = 4, RentDate = DateTime.Now, ReturnDate=(DateTime?)null });
        var result = rentalManager.Add(new Rental { Id = 8, CarId = 3, CustomerId = 4, RentDate = DateTime.Now, ReturnDate=DateTime.Now.AddDays(10) });
        Console.WriteLine(result.Message);
        //var result = rentalManager.GetAll();

        //if (result.Success)
        //{
        //    ////var deletedUser = new User();
        //    //foreach (var user in result.Data)
        //    //{
        //    //    Console.WriteLine(user.Id + "  " + user.FirstName);
        //    //    deletedUser = user;
        //    //}
        //    // rentalManager.Delete(deletedUser);
        //}
        //else
        //{
        //    Console.WriteLine(result.Message);
        //}



    }
    private static void TestUser()
    {
        UsersManager usersManager = new UsersManager(new EfUsersDal());
       var result= usersManager.Add(new User {Id=6,FirstName="11",LastName="LastName1", Email="mail",Password="1234" });
        Console.WriteLine(result.Message);
        //var result = usersManager.GetAll();

        //if (result.Success)
        //{
        //    var deletedUser = new User();
        //    foreach (var user in result.Data)
        //    {
        //        Console.WriteLine(user.Id + "  " + user.FirstName);
        //        deletedUser = user;
        //    }
        //    // usersManager.Delete(deletedUser);
        //}
        //else
        //{
        //    Console.WriteLine(result.Message);
        //}



    }
    private static void TestColor()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        //  colorManager.ColorAdd(new Color { Id = 5, Name = "renk5" });
        var result = colorManager.GetAll();
        foreach (var color in result.Data)
        {
            Console.WriteLine(color.Id + "" + color.Name);
        }
    }

    private static void TestBrand()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        //brandManager.BrandAdd(new Brand {Id=5, Name="marka5" });
        var result = brandManager.GetAll();
        foreach (var brand in result.Data)
        {
            Console.WriteLine(brand.Id + "" + brand.Name);
        }
    }

    private static void TestCar()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        carManager.Add(new Entities.Concrete.Car { Id = 5, BrandId = 4, ColorId = 4 ,Description="111",DailyPrice=5}); ;
        //var result = carManager.GetCarDetails();
        ////foreach (var car in result.Data)
        ////{
        ////    Console.WriteLine(car.Id + "" + car.CarName + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.Description);
        ////}
        //foreach (var car in result.Data)
        //{
        //    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
        //}
    }
}