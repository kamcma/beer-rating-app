using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class Brewery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BreweryID {get;set;}
        [Required]
        public string Name {get;set;}

        public Country? Country {get;set;}
        public ICollection<Beer> Beers {get;set;}

    }
}