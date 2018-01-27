using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeerApp.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        int Create(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
    }
}
