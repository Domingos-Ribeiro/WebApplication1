using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Repository;


namespace WebApplication1.UnitOfWork
{
    public class UnitOfWork : DbContext
    {
        Context context = new Context();
        Repository<Products> productsRepository;

        public Repository<Products> ProductsRepository
        {
            get
            {
                if(ProductsRepository == null)
                {
                    productsRepository = new Repository<Products>(context);
                }
                return productsRepository;
            }
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}