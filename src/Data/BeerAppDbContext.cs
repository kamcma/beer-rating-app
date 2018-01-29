using BeerApp.Data.Contracts;
using BeerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeerApp.Data
{
    public class BeerAppDbContext : DbContext,
        IBreweryDbContext,
        IBeerDbContext,
        IUserDbContext
    {
        public BeerAppDbContext(DbContextOptions<BeerAppDbContext> options)
            : base(options) { }

        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewery>()
                .HasKey(brewery => brewery.Name)
                .HasName("brewery_name_pkey");

            string beerShadowFK = "BreweryName";
            modelBuilder.Entity<Beer>()
                .Property<string>(beerShadowFK)
                .HasColumnName("brewery_name");
            modelBuilder.Entity<Beer>()
                .HasKey(new string[] { "Name", beerShadowFK })
                .HasName("beer_name_brewery_name_pkey");
            modelBuilder.Entity<Beer>()
                .HasOne(beer => beer.Brewery)
                .WithMany(brewery => brewery.Beers)
                .HasForeignKey(new string[] { beerShadowFK })
                .HasConstraintName("beer_brewery_name_fkey");
            modelBuilder.Entity<Beer>()
                .HasIndex(new string[] { beerShadowFK })
                .HasName("beer_brewery_name_idx");

            modelBuilder.Entity<User>()
                .HasKey(user => user.EmailAddress)
                .HasName("user_email_address_pkey");
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
