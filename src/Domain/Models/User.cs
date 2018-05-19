namespace BeerApp.Domain.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Country Country { get; set; }
        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
}
