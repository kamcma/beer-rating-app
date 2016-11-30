using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class Beer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerID {get;set;}
        [Required]
        public string Name {get;set;}
        public int BreweryID {get;set;}
        [ForeignKey("BreweryID")]
        public Brewery Brewery {get;set;}
        public int StyleID {get;set;}
        [ForeignKey("StyleID")]
        public Style Style {get;set;}
    }
}