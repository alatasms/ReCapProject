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



            //CarTest(carManager);

            //ColorTest(colorManager);
            BrandTest(brandManager);

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
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + " " + car.CarName + " " + car.ColorName + " " + car.BrandName + " " + car.DailyPrice);
            }
        }


    }
}
