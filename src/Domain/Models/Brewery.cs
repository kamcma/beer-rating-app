namespace BeerApp.Domain.Models
{
    public class Brewery
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public override string ToString() => this.Name;
    }
}
