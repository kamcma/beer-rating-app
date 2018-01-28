using System.Collections.Generic;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BreweryBusiness : IBreweryBusiness
    {
        private readonly IRepository<Brewery> breweryRepository;

        public BreweryBusiness(IRepository<Brewery> breweryRepository)
        {
            this.breweryRepository = breweryRepository;
        }

        public IEnumerable<Brewery> GetAllBreweries() =>
            breweryRepository.GetAll();
    }
}