using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Beer> GetAllBeersByRating(
            int pageIndex = 0,
            bool descending = true
        ) =>
            beerRepository.GetAll().AsQueryable()
                .Where(beer => beer.Ratings.Count > 0)
                .OrderByDescending(beer =>
                    beer.Ratings.Average(rating => rating.Rating ? 1.0 : 0.0)
                )
                .Page(pageIndex, 10);
    }
}
