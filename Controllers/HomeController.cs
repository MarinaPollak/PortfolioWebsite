using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PorfolioWebsite.Models;

namespace PorfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Project> _projects;

        // Constructor with default projects
        public HomeController(ILogger<HomeController> logger, List<Project> projects = null)
        {
            _logger = logger;

            // Initialize _projects either with injected test data or default data
            _projects = projects ?? new List<Project>
            {
                new Project
                {
                    Name = "E-commerce Website",
                    Type = "Web Development",
                    Description = "An online store for selling products.",
                    Author = "John Doe",
                    DatePublished = new DateTime(2023, 5, 20)
                },
                new Project
                {
                    Name = "Portfolio Website",
                    Type = "Web Design",
                    Description = "A personal website showcasing skills and projects.",
                    Author = "Jane Smith",
                    DatePublished = new DateTime(2024, 1, 10)
                },
                new Project
                {
                    Name = "Blog Platform",
                    Type = "Content Management",
                    Description = "A platform for creating and managing blog posts.",
                    Author = "Alice Johnson",
                    DatePublished = new DateTime(2022, 8, 15)
                }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var resumeData = new ResumeViewModel
            {
                Name = "Marina Pollak",
                Title = "Software Developer",
                Bio = "A passionate software developer with expertise in building modern web applications.",
                Skills = new List<string> { "C#", "ASP.NET Core", "JavaScript", "SQL", "HTML & CSS" },
                WorkExperience = new List<Job>
                {
                    new Job { JobTitle = "Software Engineer", Company = "TechCorp", Duration = "Jan 2022 - Present", Description = "Developing web applications using ASP.NET Core and Angular." },
                    new Job { JobTitle = "Web Developer", Company = "Web Solutions", Duration = "Jul 2020 - Dec 2021", Description = "Built and maintained websites for small businesses." }
                },
                Education = new List<Education>
                {
                    new Education { Degree = "B.Sc. in Computer Science", Institution = "XYZ University", Year = 2020 },
                    new Education { Degree = "Certification in Web Development", Institution = "Online Bootcamp", Year = 2019 }
                }
            };

            return View(resumeData);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Projects()
        {
            // Pass the list of projects to the view
            return View(_projects);
        }

        [HttpGet]
        public JsonResult GetProject(string projectName)
        {
            // Find the project by name
            var project = _projects.FirstOrDefault(p => p.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase));

            if (project != null)
            {
                // Return project details if found
                return Json(new
                {
                    success = true,
                    name = project.Name,
                    type = project.Type,
                    description = project.Description,
                    author = project.Author,
                    datePublished = project.GetFormattedDate()
                });
            }
            else
            {
                // Return error message if project not found
                return Json(new { success = false, message = "Project not found." });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
