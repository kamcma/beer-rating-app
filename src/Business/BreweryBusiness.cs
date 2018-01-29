using System.Collections.Generic;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BreweryBusiness : IBreweryBusiness
    {
        private readonly IBreweryDbContext breweryContext;

        public BreweryBusiness(IBreweryDbContext breweryRepository)
        {
            this.breweryContext = breweryRepository;
        }

        public IEnumerable<Brewery> GetAllBreweries() =>
            breweryContext.Breweries;
    }
}
