using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class Style
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleID {get;set;}
        [Required]
        public string Name {get;set;}
        public Yeast? Yeast {get;set;}
        public ICollection<Beer> Beers {get;set;}
    }
    public enum Yeast
    {
        ale,
        lager
    }
}