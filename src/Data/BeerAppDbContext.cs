using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using BeerApp.Domain.Models;

namespace BeerApp.Data
{
    public class BeerAppDbContext : DbContext
    {
        public BeerAppDbContext(DbContextOptions<BeerAppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(user => user.Id).HasColumnName("id");
                entity.Property(user => user.FirstName).HasColumnName("first_name");
                entity.Property(user => user.LastName).HasColumnName("last_name");
                entity.Property(user => user.EmailAddress).HasColumnName("email_address");
                entity.Property(user => user.Country).HasColumnName("country");
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.ToTable("breweries");
                entity.Property(brewery => brewery.Id).HasColumnName("id");
                entity.Property(brewery => brewery.Name).HasColumnName("name");
                entity.Property(brewery => brewery.Country).HasColumnName("country");
            });

            modelBuilder.Entity<Beer>(entity =>
            {
                entity.ToTable("beers");
                entity.Property(beer => beer.Id).HasColumnName("id");
                entity.Property(beer => beer.Name).HasColumnName("name");
                entity.Property(beer => beer.BreweryId).HasColumnName("brewery_id");
                entity.HasOne(beer => beer.Brewery)
                    .WithMany(brewery => brewery.Beers)
                    .HasForeignKey(beer => beer.BreweryId);
            });

            modelBuilder.Entity<BeerRating>(entity =>
            {
                entity.ToTable("beer_ratings");
                entity.Property(beerRating => beerRating.Id).HasColumnName("id");
                entity.Property(beerRating => beerRating.Liked).HasColumnName("liked");
                entity.Property(beerRating => beerRating.UserId).HasColumnName("user_id");
                entity.Property(beerRating => beerRating.BeerId).HasColumnName("beer_id");
                entity.HasOne(beerRating => beerRating.User)
                    .WithMany(user => user.BeerRatings)
                    .HasForeignKey(beerRating => beerRating.UserId);
                entity.HasOne(beerRating => beerRating.Beer)
                    .WithMany(beer => beer.BeerRatings)
                    .HasForeignKey(beerRating => beerRating.BeerId);

            });

            // seed

            modelBuilder.Entity<Brewery>().HasData(
                new Brewery { Id = 1, Name = "Yuengling", Country = Country.UnitedStates },
                new Brewery { Id = 2, Name = "Boston Beer", Country = Country.UnitedStates },
                new Brewery { Id = 3, Name = "Sierra Nevada", Country = Country.UnitedStates },
                new Brewery { Id = 4, Name = "New Belgium", Country = Country.UnitedStates },
                new Brewery { Id = 5, Name = "Gambrinus", Country = Country.UnitedStates },
                new Brewery { Id = 6, Name = "Lagunitas", Country = Country.UnitedStates },
                new Brewery { Id = 7, Name = "Bell's", Country = Country.UnitedStates },
                new Brewery { Id = 8, Name = "Deschutes", Country = Country.UnitedStates },
                new Brewery { Id = 9, Name = "Minhas", Country = Country.UnitedStates },
                new Brewery { Id = 10, Name = "Stone", Country = Country.UnitedStates });
        }
    }
}
