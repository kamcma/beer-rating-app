using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [Table("beer")]
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("brewery_id")]
        public int BreweryId { get; set; }

        public virtual Brewery Brewery { get; set; }

        public virtual ICollection<BeerRating> BeerRatings { get; set; }

        public override string ToString() => this.Name;
    }
}
