using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerApp.Models
{
    public class Brewery
    {
        [Key]
        public string Name {get;set;}

        public Country? Country {get;set;}
        public ICollection<Beer> Beers {get;set;}

    }
}