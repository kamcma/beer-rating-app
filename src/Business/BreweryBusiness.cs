using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BreweryBusiness : IBreweryBusiness
    {
        private readonly IBreweryDbContext breweryContext;

        public BreweryBusiness(IBreweryDbContext breweryRepository) =>
            this.breweryContext = breweryRepository;

        public IEnumerable<Brewery> GetAll(Expression<Func<Brewery, bool>> predicate = null) =>
            breweryContext.Breweries
                .Where(predicate ?? (_ => true));
    }
}
