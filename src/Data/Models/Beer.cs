namespace BeerApp.Data.Models
{
    public class Beer
    {
        public string Name { get; set; }
        public Brewery Brewery { get; set; }
        public Style Style { get; set; }
    }
}
