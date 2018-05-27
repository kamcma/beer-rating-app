using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeerApp.Domain.Contracts;
using BeerApp.Domain.Models;

namespace BeerApp.Data
{
    public class BeerRepository : ReadOnlyRepository<Beer>, IBeerRepository
    {
        public BeerRepository(BeerAppDbContext beerAppDbContext)
            : base(beerAppDbContext)
        { }

        public async Task<IEnumerable<Beer>> GetRecommendedBeers(Beer beer, int count) =>
            await beerAppDbContext_.Set<BeerRating>()
                .Where(bR => bR.Beer == beer && bR.Liked == Like.Liked)
                .Select(bR => bR.User)
                .Distinct()
                .SelectMany(user => user.BeerRatings)
                .Where(bR => bR.Beer != beer && bR.Liked == Like.Liked)
                .GroupBy(bR => bR.Beer)
                .OrderByDescending(group => group.Count())
                .Take(count)
                .Select(group => group.Key)
                .ToListAsync();
    }
}
