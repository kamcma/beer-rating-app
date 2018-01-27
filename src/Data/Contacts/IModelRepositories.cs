using BeerApp.Data.Models;

namespace BeerApp.Data.Contracts
{
    public interface IBeerRepository : IRepository<Beer> { }
    public interface IBreweryRepository : IRepository<Brewery> { }
}