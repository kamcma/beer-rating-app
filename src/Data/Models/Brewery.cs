using System.Collections.Generic;

namespace BeerApp.Data.Models
{
    public class Brewery
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public List<Beer> Beers { get; set; }

    }
}
