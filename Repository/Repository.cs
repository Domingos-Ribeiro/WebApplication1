using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    }
}