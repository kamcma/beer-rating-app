using System.Collections.Generic;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class Brewery : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Beer> Beers { get; set; }
        public override string ToString() => this.Name;
    }
}
