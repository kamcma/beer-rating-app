using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class StyleRating
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StyleRatingID {get;set;}
        public int UserID {get;set;}
        [ForeignKey("UserID")]
        public User User {get;set;}
        public int StyleID {get;set;}
        [ForeignKey("StyleID")]
        public Style Style {get;set;}
        [Required,RangeAttribute(0,5)]
        public byte Rating {get;set;}
        //public DateTime Updated {get;set;}
    }
}