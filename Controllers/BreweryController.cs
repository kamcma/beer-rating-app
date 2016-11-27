using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Controllers
{
    public class BreweryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreweryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Test()
        {
            return "Hello from Brewery Controller";
        }
        
        [HttpGet]
        public JsonResult AmericanBreweries()
        {
            var result = _context.Breweries.Where(brewery => brewery.Country == BeerApp.Models.Country.UnitedStates);
            return Json(result);
        }
    }
}