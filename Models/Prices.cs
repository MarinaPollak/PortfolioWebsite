namespace PorfolioWebsite.Models
{
    public class Prices
    {
        public string Title { get; set; }
        public int Price { get; set; } = 0;
        public string Description { get; set; } = "No description available.";
        public Prices() { }
        public Prices(string title) { Title = title; }

    }
}
