namespace BeerApp.Data.Models
{
    public class StyleRating
    {
        public bool Rating { get; set; }
        public User User { get; set; }
        public Style Style { get; set; }
    }
}
