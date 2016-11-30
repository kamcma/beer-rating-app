using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class Beer
    {
        public Brewery Brewery {get;set;}
        public string Name {get;set;}
        public Style Style {get;set;}
    }
}