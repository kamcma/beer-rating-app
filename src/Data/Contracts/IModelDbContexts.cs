using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Data.Contracts
{
    public interface IBreweryDbContext
    {
        DbSet<Brewery> Breweries { get; set; }
        int SaveChanges();
    }

    public interface IBeerDbContext
    {
        DbSet<Beer> Beers { get; set; }
        int SaveChanges();
    }

    public interface IUserDbContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }

    public interface IBeerRatingDbContext
    {
        DbSet<BeerRating> BeerRatings { get; set; }
        int SaveChanges();
    }
}
