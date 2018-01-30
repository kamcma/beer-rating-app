using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [Table("brewery")]
    public class Brewery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("country")]
        public Country Country { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
