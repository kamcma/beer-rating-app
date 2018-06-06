using System.Collections.Generic;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Country Country { get; set; }
        public List<BeerRating> BeerRatings { get; set; }
        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
}
