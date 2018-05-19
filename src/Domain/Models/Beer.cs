namespace BeerApp.Domain.Models
{
    public class Beer
    {
        public string Name { get; set; }
        public Brewery Brewery { get; set; }
        public override string ToString() => $"{Brewery.Name} {Name}";
    }
}
