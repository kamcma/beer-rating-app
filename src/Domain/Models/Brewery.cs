using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class Brewery : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Country Country { get; set; }
        public List<Beer> Beers { get; set; }
        public override string ToString() => this.Name;
    }
}
