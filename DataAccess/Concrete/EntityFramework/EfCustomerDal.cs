using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, MyDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (MyDatabaseContext context =new MyDatabaseContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.Id,
                                 CompanyName = c.CompanyName,
                                 UserName = u.FirstName,
                                 UserLastName = u.LastName,
                                 Email = u.EMail,
                                 Password=u.Password
                             };
                return result.ToList();
            }
        }
    }
}
