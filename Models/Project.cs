namespace PorfolioWebsite.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public DateTime DatePublished { get; set; }

        // Optional: A method to format the date for display
        public string GetFormattedDate()
        {
            return DatePublished.ToString("MMMM dd, yyyy");
        }
    }
}
