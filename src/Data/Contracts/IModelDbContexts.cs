using System;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data.Contracts
{
    public interface IModelDbContext : IDisposable
    {
        int SaveChanges();
    }

    public interface IBreweryDbContext : IModelDbContext
    {
        DbSet<Brewery> Breweries { get; set; }
    }

    public interface IBeerDbContext : IModelDbContext
    {
        DbSet<Beer> Beers { get; set; }
    }

    public interface IUserDbContext : IModelDbContext
    {
        DbSet<User> Users { get; set; }
    }

    public interface IBeerRatingDbContext : IModelDbContext
    {
        DbSet<BeerRating> BeerRatings { get; set; }
    }

    public interface IBeerAppDbContext :
        IBreweryDbContext,
        IBeerDbContext,
        IUserDbContext,
        IBeerRatingDbContext
    { }
}
