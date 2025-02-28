using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MoviesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create and run the web host
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specify the Startup class for configuring services and the app pipeline
                    webBuilder.UseStartup<Startup>();
                });
    }
}