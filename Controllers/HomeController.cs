using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using PorfolioWebsite.Models;
using static System.Net.WebRequestMethods;

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

            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        [Route("Contact/SubmitContactForm")]
        public IActionResult SubmitContactForm(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Create the email content
                var message = new MailMessage();
                message.To.Add("pollakmarina2@gmail.com.com"); // Replace with your email
                message.Subject = "New Contact Form Submission";
                message.Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";
                message.IsBodyHtml = false;

                // Configure the SMTP client
                using (var smtp = new SmtpClient("smtp.example.com")) // Replace with your SMTP server
                {
                    smtp.Port = 587; // Replace with your SMTP port
                    smtp.Credentials = new NetworkCredential("your_smtp_username", "your_smtp_password");
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(message);
                        TempData["SuccessMessage"] = "Your message has been sent successfully!";
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "There was an error sending your message. Please try again later.");
                    }
                }
            }


            return View("Contact", model); // Redisplay the form with validation errors (if any)
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
                Bio = "<p>Hi, I’m Marina! I’m a creative programmer, graphic designer, and software developer passionate about tackling challenges and exploring new ideas. " +
                      "Originally from Russia—a country renowned for producing exceptional developers—I’m now pursuing a degree in programming at Columbia College Chicago.</p>" +
                      "<p>Before moving to the U.S., I earned a degree in Marketing in Saint-Petersburg, where I developed strong skills in strategic thinking and creativity. " +
                      "My American journey started at Santa Monica College, where I studied nutrition inspired by my family’s experience with diabetes and my passion for a healthy lifestyle. " +
                      "During this time, I became skilled in providing nutrition advice and crafting healthy recipes.</p>" +
                      "<p>Later, I discovered my love for programming at Harold Washington College, starting with HTML and CSS.</p>" +
                      "<p>Since then, I’ve built my portfolio website in .NET MVC, deployed and hosted on Azure, and created several websites for friends using WordPress and GoDaddy. " +
                      "I’m also proficient with Google Search Console and skilled in search engine optimization.</p>" +
                      "<p>In addition to being proficient in C# and C++, fluent in Figma, and a Photoshop Certified Professional, I’m passionate about blending creativity with technology. " +
                      "Whether it’s designing seamless user experiences, building innovative apps, or expressing my ideas through drawing and digital art, I love bringing projects to life.</p>" +
                      "<p>In my free time, I enjoy exploring new technologies, collaborating with other creatives, and helping others with personalized nutrition advice and healthy recipes to support a balanced lifestyle.</p>",
                Skills = new List<string> { "C#", "ASP.NET Core", "JavaScript", "SQL", "HTML & CSS", "Figma", "Photoshop", "Illustrator", "InDesign" },
                WorkExperience = new List<Job>
                {
                    new Job { JobTitle = "Freelance", Company = "Feverr", Duration = "Jan 2025 - Present", Description = "Photo Retouching, Color Grading" },
                    new Job { JobTitle = "Freelance", Company = "Feverr", Duration = "Present", Description = "Built and maintained websites for small businesses." }
                },
                Education = new List<Education>
                {
                    new Education { Degree = "Associataed Degree", Institution = "Harold Washington", Year = 2022 },
                    new Education { Degree = "Programming", Institution = "Columbia College Chicago", Year = 2026 }
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
            // Initialize _projects either with injected test data or default data
             var  projects =  new List<Project>
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

            // Pass the list of projects to the view
            return View(projects);
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

        public IActionResult Reviews()
        {
            var reviews = new List<Review>
            {
                new Review { Author = "John Doe", Content = "Amazing service!", Rating = 5 },
                new Review { Author = "Jane Smith", Content = "Great experience!", Rating = 4 },
                new Review { Author = "John Doe", Content = "Amazing service!", Rating = 5 },
                new Review { Author = "Jane Smith", Content = "Great experience!", Rating = 4 },
                new Review { Author = "Jane Smith", Content = "Great experience!", Rating = 4 },
                new Review { Author = "John Doe", Content = "Amazing service!", Rating = 5 },
                new Review { Author = "Jane Smith", Content = "Great experience!", Rating = 4 }
            };
            return View(reviews);
        }

        public IActionResult Prices()
        {
            var price = new List<Prices>
            {
                new Prices { Title = "Basic Plan", Price = 10, Description = "Includes basic features" },
                new Prices { Title = "Standard Plan", Price = 20, Description = "Includes standard features" },
                new Prices { Title = "Premium Plan", Price = 30, Description = "Includes premium features" },

            };
        
            return View(price);
        }


        public IActionResult Illustration()
        {
            // Replace with actual data
            var model = new List<Illustration>
            {
                new Illustration { Title = "Item 1", Description = "Description for Item 1" , ImageUrl = "/images/portfolio_byrembrandt_2069.PNG" },
                new Illustration { Title = "Item 2", Description = "Description for Item 2" , ImageUrl = "/images/portfolio_byrembrandt_2070.PNG" },
                new Illustration { Title = "Item 3", Description = "Description for Item 3" , ImageUrl = "/images/portfolio_byrembrandt_2072.PNG" },
                new Illustration { Title = "Item 4", Description = "Description for Item 4" , ImageUrl = "/images/portfolio_byrembrandt_2073.PNG" }
            };

            // Pass the model to the view
            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
