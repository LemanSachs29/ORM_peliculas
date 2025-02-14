using Microsoft.EntityFrameworkCore;

using ORM;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Clases
{
    public abstract class CineContexto<TEntity, TContext> : CineContext
      where TEntity : class, new()
        where TContext : CineContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;database=cine;user=root;password=admin",
               new MySqlServerVersion(new Version(8, 0, 25))); // Especifica la versión de MySQL

        }


        public new void Add<TEntity>(TEntity entity)
        where TEntity : class
        {
            base.Add(entity);
            base.SaveChanges();
        }


        public new void Update<TEntity>(TEntity entity)
        where TEntity : class
        {
            base.Update(entity);
            base.SaveChanges();
        }


        public new void Remove<TEntity>(TEntity entity)
      where TEntity : class
        {
            base.Remove(entity);
            base.SaveChanges();
        }


        /*
                public new void AddItems<TEntity>(IEnumerable<TEntity> entity)
               where TEntity : class
                {
                    base.Add(entity);
                    base.SaveChanges();
                }
        */

    }
}
