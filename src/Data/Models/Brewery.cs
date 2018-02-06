using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [Table("brewery")]
    public class Brewery
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("country")]
        public Country Country { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public override string ToString() => this.Name;
    }
}
