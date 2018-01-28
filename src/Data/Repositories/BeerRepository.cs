using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data
{
    public class BeerRepository : IRepository<Beer>
    {
        private readonly IBeerAppDbContext context;

        public BeerRepository(IBeerAppDbContext context)
        {
            this.context = context;
        }

        public int Create(Beer beer)
        {
            context.Beers.Add(beer);
            return context.SaveChanges();
        }

        public Beer Get(Expression<Func<Beer, bool>> predicate) =>
            context.Beers
                .Include(beer => beer.Brewery)
                .Include(beer => beer.Ratings)
                .FirstOrDefault(predicate ?? (_ => true));

        public IEnumerable<Beer> GetAll(Expression<Func<Beer, bool>> predicate = null) =>
            context.Beers
                .Include(beer => beer.Brewery)
                .Include(beer => beer.Ratings)
                .Where(predicate ?? (_ => true));

        public int Update(Beer beer)
        {
            context.Beers.Update(beer);
            return context.SaveChanges();
        }

        public int Delete(Beer beer)
        {
            context.Beers.Remove(beer);
            return context.SaveChanges();
        }
    }
}
