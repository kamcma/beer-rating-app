using Microsoft.EntityFrameworkCore;
using BeerApp.Models;

namespace BeerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Brewery> Breweries {get;set;}
        public DbSet<Style> Styles {get;set;}
        public DbSet<Beer> Beers {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<BeerRating> BeerRatings {get;set;}
        public DbSet<StyleRating> StyleRatings {get;set;}
    }
}