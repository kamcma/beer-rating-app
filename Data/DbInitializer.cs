using System.Linq;
using BeerApp.Models;

namespace BeerApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var breweries = new Brewery[] {
                new Brewery{Name="Sierra Nevada Brewing Co.",Country=Country.UnitedStates},
                new Brewery{Name="Great Lakes Brewing Company",Country=Country.UnitedStates},
                new Brewery{Name="Flying Dog Brewery",Country=Country.UnitedStates},
                new Brewery{Name="Dogfish Head Brewery",Country=Country.UnitedStates},
                new Brewery{Name="Ballast Point Brewing Company",Country=Country.UnitedStates},
                new Brewery{Name="Revolution Brewing",Country=Country.UnitedStates},
            };

            foreach (Brewery b in breweries)
            {
                context.Breweries.Add(b);
            }
            
            context.SaveChanges();

            var styles = new Style[] {
                new Style{Name="pale ale",Yeast=Yeast.ale},
                new Style{Name="Indian pale ale",Yeast=Yeast.ale},
                new Style{Name="double India pale ale",Yeast=Yeast.ale},
                new Style{Name="brown ale",Yeast=Yeast.ale},
                new Style{Name="Scotch ale",Yeast=Yeast.ale},
                new Style{Name="stout",Yeast=Yeast.ale},
                new Style{Name="porter",Yeast=Yeast.ale},
                new Style{Name="pilsner",Yeast=Yeast.lager},
                new Style{Name="wheat ale",Yeast=Yeast.ale},
                new Style{Name="California common",Yeast=Yeast.lager},
            };

            foreach (Style s in styles)
            {
                context.Styles.Add(s);
            }

            context.SaveChanges();

            var beers = new Beer[] {
                new Beer{Name="Burning River",Brewery=context.Breweries.Single(b=>b.Name.Contains("Great Lakes")),Style=context.Styles.Single(s=>s.Name=="pale ale")},
                new Beer{Name="Doggie Style",Brewery=context.Breweries.Single(b=>b.Name.Contains("Flying Dog")),Style=context.Styles.Single(s=>s.Name=="pale ale")},
                new Beer{Name="Snake Dog",Brewery=context.Breweries.Single(b=>b.Name.Contains("Flying Dog")),Style=context.Styles.Single(s=>s.Name=="Indian pale ale")},
            };

            foreach (Beer b in beers)
            {
                context.Beers.Add(b);
            }

            context.SaveChanges();
        }
    }
}