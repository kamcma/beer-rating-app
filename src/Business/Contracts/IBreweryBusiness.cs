using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeerApp.Data.Models;

namespace BeerApp.Business.Contracts
{
    public interface IBreweryBusiness
    {
        IEnumerable<Brewery> GetAll(Expression<Func<Brewery, bool>> predicate = null);
    }
}
