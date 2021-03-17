using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyDatabaseContext context=new MyDatabaseContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto { Id = c.Id, CarName = c.CarName, ColorName = co.Name, BrandName = b.Name, DailyPrice=c.DailyPrice};
                return result.ToList();
            }
        }
    }
}
