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
    public class EfColorDal : IColorDal
    {
        public void Add(Color color)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var colorToAdded = context.Entry(color);
                colorToAdded.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color color)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var colorToDeleted = context.Entry(color);
                colorToDeleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                return filter == null
                 ? context.Set<Color>().ToList()
                : context.Set<Color>().Where(filter).ToList();

            }
        }

        public void Update(Color color)
        {
            using (MyCarDbContext context=new MyCarDbContext())
            {
                var colorToUpdate = context.Entry(color);
                colorToUpdate.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
