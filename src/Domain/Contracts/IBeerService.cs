using System.Collections.Generic;
using BeerApp.Domain.Models;

namespace BeerApp.Domain.Contracts
{
    public interface IBeerService
    {
        IEnumerable<Beer> GetRecommendedBeers(User user);
    }
}
