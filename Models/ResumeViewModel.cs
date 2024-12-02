namespace PorfolioWebsite.Models
{
    public class ResumeViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public List<string> Skills { get; set; }
        public List<Job> WorkExperience { get; set; }
        public List<Education> Education { get; set; }
    }

    public class Job
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }

    public class Education
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public int Year { get; set; }
    }
}
