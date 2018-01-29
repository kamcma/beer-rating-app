using System;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data.Contracts
{
    public interface IBeerAppDbContext : IDisposable
    {
        DbSet<Beer> Beers { get; set; }
        DbSet<Brewery> Breweries { get; set; }
        DbSet<BeerRating> BeerRatings { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
