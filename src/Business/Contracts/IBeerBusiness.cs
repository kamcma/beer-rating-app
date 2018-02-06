using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeerApp.Data.Models;

namespace BeerApp.Business.Contracts
{
    public interface IBeerBusiness
    {
        IEnumerable<Beer> GetAll(Expression<Func<Beer, bool>> predicate = null);
        IEnumerable<Beer> GetAllByRating(int pageIndex, bool descending);
        IEnumerable<Beer> GetCoLikedBeers(Beer beer);
    }
}
