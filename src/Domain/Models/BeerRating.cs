using System.ComponentModel.DataAnnotations;
using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class BeerRating : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Like Liked { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
