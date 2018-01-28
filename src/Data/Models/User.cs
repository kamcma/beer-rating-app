using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [Table("user")]
    public class User
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email_address")]
        public string EmailAddress { get; set; }

        public Country Country { get; set; }

        public List<BeerRating> BeerRatings { get; set; }
    }
}
