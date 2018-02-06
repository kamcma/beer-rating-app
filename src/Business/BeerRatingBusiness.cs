using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BeerApp.Business.Contracts;
using BeerApp.Data.Contracts;
using BeerApp.Data.Models;

namespace BeerApp.Business
{
    public class BeerRatingBusiness : IBeerRatingBusiness
    {
        private readonly IBeerRatingDbContext beerRatingContext;

        public BeerRatingBusiness(IBeerRatingDbContext beerRatingContext) =>
            this.beerRatingContext = beerRatingContext;

        public IEnumerable<BeerRating> GetAll(Expression<Func<BeerRating, bool>> predicate = null) =>
            beerRatingContext.BeerRatings
                .Where(predicate ?? (_ => true));
    }
}
