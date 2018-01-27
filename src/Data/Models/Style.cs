using System.Collections.Generic;
namespace BeerApp.Data.Models
{
    public class Style
    {
        public string Name { get; set; }
        public Yeast Yeast { get; set; }
        public List<Beer> Beers { get; set; }
    }
}
