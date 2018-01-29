using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly IBeerAppDbContext context;

        public BreweryRepository(IBeerAppDbContext context)
        {
            this.context = context;
        }

        public int Create(Brewery brewery)
        {
            context.Breweries.Add(brewery);
            return context.SaveChanges();
        }

        public Brewery Get(Expression<Func<Brewery, bool>> predicate) =>
            context.Breweries
                .Include(brewery => brewery.Beers)
                .FirstOrDefault(predicate ?? (_ => true));

        public IEnumerable<Brewery> GetAll(Expression<Func<Brewery, bool>> predicate = null) =>
            context.Breweries
                .Include(brewery => brewery.Beers)
                .Where(predicate ?? (_ => true));

        public int Update(Brewery brewery)
        {
            context.Breweries.Update(brewery);
            return context.SaveChanges();
        }

        public int Delete(Brewery brewery)
        {
            context.Breweries.Remove(brewery);
            return context.SaveChanges();
        }
    }
}
