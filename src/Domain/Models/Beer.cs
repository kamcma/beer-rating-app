using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class Beer : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public List<BeerRating> BeerRatings { get; set; }
        public override string ToString() => $"{Brewery.Name} {Name}";
    }
}
