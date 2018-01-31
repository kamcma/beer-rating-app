using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [NotMapped]
    [Table("beer_rating")]
    public class BeerRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("thumbs_up")]
        public bool ThumbsUp { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Column("beer_id")]
        public int BeerId { get; set; }

        public virtual Beer Beer { get; set; }

        public override string ToString() => this.ThumbsUp ? "👍" : "👎";
    }
}
