using System.Collections.Generic;
using BeerApp.Data.Models;

namespace BeerApp.Business.Contracts
{
    public interface IBreweryBusiness
    {
        IEnumerable<Brewery> GetAllBreweries();
    }
}
