namespace SchoolMaster.WebAPI
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    /// <summary>
    /// Main class for the SchoolMaster Web API.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Gets the web service configuration file.
        /// </summary>
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .CreateLogger();

            try
            {
                Log.Information($"Starting the School Master web service. Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The School Master host terminated unexpectedly");
            }
            finally
            {
                Log.Information("Shutting down the School Master web service.");
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Setting up the .NET generic host for ASP.NET Core.
        /// </summary>
        /// <param name="args">Command line arguments passed in to "Main".</param>
        /// <returns>HostBuilder.</returns>
        [CLSCompliant(false)]
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                            .UseSerilog()
                            .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseStartup<Startup>()
                                .UseConfiguration(Configuration);
                            });
        }
    }
}
