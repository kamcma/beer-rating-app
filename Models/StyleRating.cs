using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class StyleRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleRatingID {get;set;}
        [Required]
        public int UserID {get;set;}
        public User User {get;set;}
        [Required]
        public int StyleID {get;set;}
        public Style Style {get;set;}
        [Required]
        [RangeAttribute(0,5)]
        public byte Rating {get;set;}
        public DateTime Updated {get;set;}
    }
}