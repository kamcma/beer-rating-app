using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerApp.Data;

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
        public JsonResult Breweries()
        {
            return Json(_context.Breweries.ToList());
        }
    }
}