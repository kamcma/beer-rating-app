using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BeerBusiness : IBeerBusiness
    {
        private readonly IBeerDbContext beerContext;

        public BeerBusiness(IBeerDbContext beerContext) =>
            this.beerContext = beerContext;

        public IEnumerable<Beer> GetAll(Expression<Func<Beer, bool>> predicate = null) =>
            beerContext.Beers
                .Where(predicate ?? (_ => true));

        public IEnumerable<Beer> GetAllByRating(
            int pageIndex = 0,
            bool descending = true
        ) =>
            beerContext.Beers
                .Where(beer => beer.BeerRatings.Count > 0)
                .OrderByDescending(beer =>
                    beer.BeerRatings.Average(rating => rating.ThumbsUp ? 1.0 : 0.0)
                )
                .Page(pageIndex, 10);

        public IEnumerable<Beer> GetCoLikedBeers(Beer beer) =>
            beerContext.Beers.Attach(beer)
                .Collection(beerEntity => beerEntity.BeerRatings).Query()
                .Where(beerRating => beerRating.ThumbsUp)
                .Select(beerRating => beerRating.User).Distinct()
                .SelectMany(user => user.BeerRatings)
                .Where(beerRating => beerRating.ThumbsUp)
                .GroupBy(beerRating => beerRating.Beer)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key);
    }
}
