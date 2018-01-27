using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BeerApp.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public int Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate) =>
            context.Set<TEntity>().FirstOrDefault(predicate);

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null) =>
            context.Set<TEntity>().Where(predicate ?? (_ => true));

        public int Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }
    }
}
