using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class BeerRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerRatingID {get;set;}
        [Required]
        public int UserID {get;set;}
        public User User {get;set;}
        [Required]
        public int BeerID {get;set;}
        public Beer Beer {get;set;}
        [Required]
        [RangeAttribute(0,5)]
        public byte Rating {get;set;}
        public DateTime Updated {get;set;}
    }
}