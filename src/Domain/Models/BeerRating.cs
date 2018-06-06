using BeerApp.Domain.Contracts;

namespace BeerApp.Domain.Models
{
    public class BeerRating : IEntity
    {
        public int Id { get; set; }
        public Like Liked { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
