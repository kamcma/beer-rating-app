using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [Table("beer")]
    public class Beer
    {
        [Column("name")]
        public string Name { get; set; }

        public Brewery Brewery { get; set; }

        public List<BeerRating> Ratings { get; set; }
    }
}
