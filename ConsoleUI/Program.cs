using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            



            //brandManager.Add(new Brand { Name="Toyota" });
            //brandManager.Add(new Brand { Name="Fiat"});
            //brandManager.Update(new Brand { Id = 1, Name = "Mercedes" });
            //brandManager.Delete(new Brand { Id = 1 });


            //colorManager.Add(new Color {  Name = "Yellow" });
            //colorManager.Add(new Color {  Name = "LightBlue" });
            //colorManager.Update(new Color { Id = 2003, Name = "DarkBlue" });
            //colorManager.Delete(new Color { Id = 2002 });

            //carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 500, ModelYear = 2018, Description = "Red Fiat Car" });
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 800, ModelYear = 2020, Description = "Purple Toyota Car" });
            //carManager.Delete(new Car { Id = 2007 });
            //carManager.Update(new Car { Id = 2008, BrandId = 2, ColorId = 1, DailyPrice = 100, ModelYear = 2001, CarName = "My Car" });

            //customerManager.Add(new Customer { CompanyName = "Ünanlar", UserId = 2});
            //customerManager.Update(new Customer { Id=1002, UserId=2,CompanyName = "Rüzgarlar" });
            //customerManager.Delete(new Customer { Id=1002});



            //rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2020, 12, 29), ReturnDate = new DateTime(2021, 03, 20) });
            //rentalManager.Delete(new Rental { Id = 1 });
            //rentalManager.Update(new Rental { Id = 1, CarId=2,CustomerId=1,RentDate=new DateTime(2020,12,13),ReturnDate=new DateTime(2021,01,13)});


            //RentalDetailTest();
            //CustomerDetailTest();
            //CarTest(carManager);
            //ColorTest(colorManager);
            //BrandTest(brandManager);
            //CustomerTest(customerManager);




            

        }

        private static void RentalDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();

            foreach (var rental in result.Data)
            {

                Console.WriteLine(rental.CarName+" "+rental.CustomerName+" "+rental.CustomerLastName+" "+rental.ColorName+" "+rental.BrandName+" "+rental.DailyPrice+" "+rental.RentDate+" "+rental.ReturnDate);

            }
        }
        private static void CustomerDetailTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetail();

            foreach (var rental in result.Data)
            {

                Console.WriteLine(rental.CompanyName+" "+rental.UserName+" "+rental.UserLastName+" "+rental.Email+" "+rental.Password);

            }
        }


        private static void CustomerTest(CustomerManager customerManager)
        {
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName + " " + customer.Id);
            }
        }

        private static void BrandTest(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTest(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }
        
        private static void CarTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.Id + " " + car.CarName + " " + car.ColorName + " " + car.BrandName + " " + car.DailyPrice);
                }
            }

            
        }


    }
}
