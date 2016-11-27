using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Controllers
{
    public class BeerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Test()
        {
            return "Hello from Beer Controller";
        }
        
        [HttpGet]
        public JsonResult Beers()
        {
            var result = _context.Beers;
            return Json(result);
        }
    }
}