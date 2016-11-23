using System.Linq;
using BeerApp.Models;

namespace BeerApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Breweries.Any())
            {
                context.Database.EnsureDeleted();
            }
            context.Database.EnsureCreated();

            var breweries = new Brewery[] {
                new Brewery{Name="Sierra Nevada Brewing Co.",Country=Country.UnitedStates},
                new Brewery{Name="Great Lakes Brewing Company",Country=Country.UnitedStates},
                new Brewery{Name="Flying Dog Brewery",Country=Country.UnitedStates},
                new Brewery{Name="Dogfish Head Brewery",Country=Country.UnitedStates},
                new Brewery{Name="Ballast Point Brewing Company",Country=Country.UnitedStates},
            };

            foreach (Brewery b in breweries)
            {
                context.Breweries.Add(b);
            }
            context.SaveChanges();
        }
    }
}