using System.Collections.Generic;
using System.Threading.Tasks;
using BeerApp.Domain.Models;

namespace BeerApp.Domain.Contracts
{
    public interface IBeerRepository : IReadOnlyRepository<Beer>
    {
        Task<IEnumerable<Beer>> GetRecommendedBeers(Beer beer, int count);
    }
}
