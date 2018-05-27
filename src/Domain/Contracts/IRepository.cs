using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BeerApp.Domain.Contracts
{
    public interface IReadOnlyRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> Set();
        Task<IEnumerable<T>> Set(Expression<Func<T, bool>> predicate);
    }

    public interface IRepository<T> : IReadOnlyRepository<T> where T : class, IEntity
    {
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
