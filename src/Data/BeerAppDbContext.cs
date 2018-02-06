using BeerApp.Data.Contracts;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeerApp.Data
{
    public class BeerAppDbContext : DbContext,
        IBreweryDbContext,
        IBeerDbContext,
        IUserDbContext,
        IBeerRatingDbContext
    {
        public BeerAppDbContext(DbContextOptions<BeerAppDbContext> options)
            : base(options) { }

        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<BeerRating> BeerRatings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.EmailAddress);

            modelBuilder.Entity<Brewery>()
                .HasKey(brewery => brewery.Name);

            modelBuilder.Entity<Beer>()
                .HasKey(beer => new { beer.Name, beer.BreweryName });
            modelBuilder.Entity<Beer>()
                .HasOne(beer => beer.Brewery)
                .WithMany(brewery => brewery.Beers)
                .HasForeignKey(beer => beer.BreweryName);

            modelBuilder.Entity<BeerRating>()
                .HasKey(beerRating => new
                {
                    beerRating.UserEmailAddress,
                    beerRating.BeerName,
                    beerRating.BreweryName
                });
            modelBuilder.Entity<BeerRating>()
                .HasOne(beerRating => beerRating.User)
                .WithMany(user => user.BeerRatings)
                .HasForeignKey(beerRating => beerRating.UserEmailAddress);
            modelBuilder.Entity<BeerRating>()
                .HasOne(beerRating => beerRating.Beer)
                .WithMany(beer => beer.BeerRatings)
                .HasForeignKey(beerRating => new
                {
                    beerRating.BeerName,
                    beerRating.BreweryName
                });
        }
    }

    public class BeerAppContextFactory : IDesignTimeDbContextFactory<BeerAppDbContext>
    {
        public BeerAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BeerAppDbContext>();
            optionsBuilder.UseNpgsql("postgresql://localhost:5432");
            return new BeerAppDbContext(optionsBuilder.Options);
        }
    }
}
