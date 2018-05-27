using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public Country Country { get; set; }
        public List<BeerRating> BeerRatings { get; set; }
        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
}
