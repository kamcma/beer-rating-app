using BeerApp.Data.Models;

namespace BeerApp.Data.Contracts
{
    public interface IBreweryRepository : IRepository<Brewery> { }
    public interface IBeerRepository : IRepository<Beer> { }
}
