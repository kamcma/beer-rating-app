using System.Collections.Generic;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class Beer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public List<BeerRating> BeerRatings { get; set; }
        public override string ToString() => $"{Brewery.Name} {Name}";
    }
}
