using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Repository
{
    public class Repository<T> : IDisposable where T : class
    {
        Context Context;
        DbSet<T> DbSet;
        public Repository(Context context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T FindById(int Id)
        {
            return DbSet.Find(Id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}