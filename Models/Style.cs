using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class Style
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleID {get;set;}
        public string Name {get;set;}
        public Yeast Yeast {get;set;}
    }
    public enum Yeast
    {
        ale,
        lager
    }
}