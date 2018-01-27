using System.Collections.Generic;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BreweryBusiness : IBreweryBusiness
    {
        private readonly IBreweryRepository breweryRepository;

        public BreweryBusiness(IBreweryRepository breweryRepository)
        {
            this.breweryRepository = breweryRepository;
        }

        public IEnumerable<Brewery> GetAllBreweries() =>
            breweryRepository.GetAll();
    }
}