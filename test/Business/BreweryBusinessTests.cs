using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BeerApp.Business;
using BeerApp.Data.Models;
using System.Linq;

namespace BeerApp.BusinessTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnsBreweries()
        {
            var context = new BeerAppDbContext(
                new DbContextOptionsBuilder<BeerAppDbContext>()
                    .UseInMemoryDatabase(databaseName: $"{MethodBase.GetCurrentMethod()}")
                    .Options
            );

            context.Breweries.Add(new Brewery
            {
                Name = "Sierra Nevada Brewing Company",
                Country = Country.UnitedStates
            });
            context.Breweries.Add(new Brewery
            {
                Name = "Three Floyds Brewing",
                Country = Country.UnitedStates
            });
            context.Breweries.Add(new Brewery
            {
                Name = "Bass Brewery",
                Country = Country.UnitedKingdom
            });
            context.SaveChanges();

            var service = new BreweryBusiness(context);

            var breweries = service.GetAllBreweries();

            Assert.AreEqual(3, breweries.Count());
        }
    }
}
