using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyDatabaseContext context =new MyDatabaseContext())
            {
                var result = (from r in context.Rentals
                    join cr in context.Cars on r.CarId equals cr.Id
                    join br in context.Brands on cr.BrandId equals br.Id
                    join cu in context.Customers on r.CustomerId equals cu.Id
                    join us in context.Users on cu.UserId equals us.Id
                    select new RentalDetailDto
                    {
                        RentalId = r.Id,
                        CustomerFirstName = us.FirstName,
                        CustomerLastName = us.LastName,
                        CarName = cr.CarName,
                        BrandName = br.Name,
                        DailyPrice = cr.DailyPrice,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    }).ToList();
                return result;
            }
        }
    }
}
