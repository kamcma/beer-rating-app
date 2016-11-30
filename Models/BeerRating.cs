using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class BeerRating
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BeerRatingID {get;set;}
        public int UserID {get;set;}
        [ForeignKey("UserID")]
        public User User {get;set;}
        public int BeerID {get;set;}
        [ForeignKey("BeerID")]
        public Beer Beer {get;set;}
        [Required,RangeAttribute(0,5)]
        public byte Rating {get;set;}
        //public DateTime Updated {get;set;}
    }
}