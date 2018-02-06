using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeerApp.Data.Models;

namespace BeerApp.Business.Contracts
{
    public interface IBeerRatingBusiness
    {
        IEnumerable<BeerRating> GetAll(Expression<Func<BeerRating, bool>> predicate = null);
    }
}
