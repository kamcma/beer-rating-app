using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeerApp.Domain.Contracts;

namespace BeerApp.Data
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class, IEntity
    {
        protected readonly BeerAppDbContext beerAppDbContext_;

        public ReadOnlyRepository(BeerAppDbContext beerAppDbContext) =>
            beerAppDbContext_ = beerAppDbContext;

        public async Task<IEnumerable<T>> Get() =>
            await beerAppDbContext_.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate) =>
            await beerAppDbContext_.Set<T>().Where(predicate).ToListAsync();
    }

    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : class, IEntity
    {
        public Repository(BeerAppDbContext beerAppDbContext) : base(beerAppDbContext) { }

        public async Task<int> Add(T entity)
        {
            beerAppDbContext_.Set<T>().Add(entity);
            return await beerAppDbContext_.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            beerAppDbContext_.Set<T>().Remove(entity);
            return await beerAppDbContext_.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            beerAppDbContext_.Set<T>().Update(entity);
            return await beerAppDbContext_.SaveChangesAsync();
        }
    }
}
