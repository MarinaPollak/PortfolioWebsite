using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace PorfolioWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); // Add CSRF protection globally
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Enable HTTP Strict Transport Security
            }
            else
            {
                app.UseDeveloperExceptionPage(); // Show detailed error pages in development
            }

            app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
            app.UseStaticFiles(); // Serve static files like CSS, JS, images
            app.UseRouting();
            app.UseAuthorization(); // Add Authorization middleware

            // Map controller routes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Add a custom route for admin (optional)
            app.MapControllerRoute(
                name: "admin",
                pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}