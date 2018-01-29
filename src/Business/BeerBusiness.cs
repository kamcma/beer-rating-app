using System.Collections.Generic;
using System.Linq;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BeerBusiness : IBeerBusiness
    {
        private readonly IBeerDbContext beerContext;

        public BeerBusiness(IBeerDbContext beerRepository)
        {
            this.beerContext = beerRepository;
        }

        public IEnumerable<Beer> GetAllBeers() =>
            beerContext.Beers;

        public IEnumerable<Beer> GetAllBeersByRating(
            int pageIndex = 0,
            bool descending = true
        ) =>
            beerContext.Beers
                .Where(beer => beer.Ratings.Count > 0)
                .OrderByDescending(beer =>
                    beer.Ratings.Average(rating => rating.ThumbsUp ? 1.0 : 0.0)
                )
                .Page(pageIndex, 10);
    }
}
