using System.Collections.Generic;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BeerBusiness : IBeerBusiness
    {
        private readonly IBeerRepository beerRepository;

        public BeerBusiness(IBeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }

        public IEnumerable<Beer> GetAllBeers() =>
            beerRepository.GetAll();
    }
}
