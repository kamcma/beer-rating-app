namespace BeerApp.Data.Models
{
    public class BeerRating
    {
        public bool Rating { get; set; }
        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
