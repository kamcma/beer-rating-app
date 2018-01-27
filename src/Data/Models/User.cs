using System.Collections.Generic;

namespace BeerApp.Data.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Country Country { get; set; }
        public List<BeerRating> BeerRatings { get; set; }
        public List<StyleRating> StyleRatings { get; set; }
    }
}
