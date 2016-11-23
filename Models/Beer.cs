using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class Beer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerID {get;set;}
        public int BreweryID {get;set;}
        public Brewery Brewery {get;set;}
        public string Name {get;set;}
        public int StyleID {get;set;}
        public Style Style {get;set;}
    }
}