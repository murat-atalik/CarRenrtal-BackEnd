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
        public void Add(Brand brand)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {

                var brandToadded = context.Entry(brand);
                brandToadded.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {

                var carToDelete = context.Entry(brand);
                carToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                return filter == null
                 ? context.Set<Brand>().ToList()
                : context.Set<Brand>().Where(filter).ToList();

            }
        }

        public void Update(Brand brand)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var updatedBrand = context.Entry(brand);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
