using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (MyDatabaseContext contex = new MyDatabaseContext())
            {
                var addedEntity = contex.Entry(entity);
                addedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (MyDatabaseContext contex = new MyDatabaseContext())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (MyDatabaseContext context =new MyDatabaseContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }


        public void Update(Brand entity)
        {
            using (MyDatabaseContext contex = new MyDatabaseContext())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
