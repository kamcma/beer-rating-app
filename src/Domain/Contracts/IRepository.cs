using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BeerApp.Domain.Contracts
{
    public interface IRepository<T>
    {
        Task<int> Add(T entity);
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
