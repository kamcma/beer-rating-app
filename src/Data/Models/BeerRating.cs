using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [NotMapped]
    [Table("beer_rating")]
    public class BeerRating
    {
        [Column("thumbs_up")]
        public bool ThumbsUp { get; set; }

        [Column("user_email_address")]
        public string UserEmailAddress { get; set; }

        public virtual User User { get; set; }

        [Column("beer_name")]
        public string BeerName { get; set; }

        [Column("brewery_name")]
        public string BreweryName { get; set; }

        public virtual Beer Beer { get; set; }

        public override string ToString() => this.ThumbsUp ? "👍" : "👎";
    }
}
