using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        [EmailAddress]
        public string EmailAddress {get;set;}
        public Country Country {get;set;}
        public ICollection<BeerRating> BeerRatings {get;set;}
        public ICollection<StyleRating> StyleRatings {get;set;}
    }
}