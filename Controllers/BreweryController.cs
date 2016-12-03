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

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public JsonResult Breweries()
        {
            var result = _context.Breweries;
            return Json(result);
        }
    }
}