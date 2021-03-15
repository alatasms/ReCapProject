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

            brandManager.Add(new Brand { Name="Toyota" });
            brandManager.Add(new Brand { Name="Fiat"});

            colorManager.Add(new Color {  Name = "Red" });
            colorManager.Add(new Color {  Name = "LightBlue" });

            carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 500, ModelYear = 2018, Description = "Red Fiat Car" });
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 800, ModelYear = 2020, Description = "Purple Toyota Car" });

            foreach (var car in brandManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }
            
        }
    }
}
