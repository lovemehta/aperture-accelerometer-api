using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApertureScience.AccelerometerApi
{
    /// <summary>
    /// The Program class is the entry point of the application.
    /// It configures and starts the web host.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method is the entry point of the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Create and run the host
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Configures and creates the host builder.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        /// <returns>An IHostBuilder configured with the default settings and the Startup class.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specifies the Startup class to use for configuring the web host
                    webBuilder.UseStartup<Startup>();
                });
    }
}
