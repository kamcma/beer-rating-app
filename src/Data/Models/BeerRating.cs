using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThumbsUp = System.Boolean;

namespace BeerApp.Data.Models
{
    [Table("beer_rating")]
    public class BeerRating
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("thumbs_up")]
        public ThumbsUp Rating { get; set; }

        public User User { get; set; }

        public Beer Beer { get; set; }
    }
}
