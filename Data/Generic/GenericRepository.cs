using Data.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Data.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ILogger logger;
        protected ProjectContext context;
        internal DbSet<T> dbSet;


        public GenericRepository(ProjectContext context, ILogger logger)
        {
            this.logger = logger;
            this.context = context;

            dbSet = context.Set<T>();
        }


        public virtual void Add(T entity)
        {
            //add
           dbSet.Add(entity);
           context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            //delete by id
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            // get all
            if (filter is null)
            {
                return dbSet.ToList();
            }
            else
            {
                return dbSet.Where(filter);

            }


        }

        public virtual T GetById(int id)
        {
            //get by id
            var model = dbSet.Find(id);
            return model;
        }

        public virtual void Update(T entity)
        {
            //update
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }
}

