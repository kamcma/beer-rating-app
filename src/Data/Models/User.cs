using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.Data.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email_address")]
        public string EmailAddress { get; set; }

        [Column("country")]
        public Country Country { get; set; }

        public virtual ICollection<BeerRating> BeerRatings { get; set; }

        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
}
