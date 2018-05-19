namespace BeerApp.Domain.Models
{
    public class BeerRating
    {
        public Like Liked { get; set; }
        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
