using System;
using Faculty.Data;
using Faculty.Data.DataSeeding;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Test2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            IHostingEnvironment env = host.Services.GetService<IHostingEnvironment>();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    FacultyContext FacultyContext = services.GetRequiredService<FacultyContext>();
                    FacultyContext.Database.EnsureCreated();
                    DataDbInitializer.Seed(FacultyContext);

                    AuthenticationContext AuthenticationContext = services.GetRequiredService<AuthenticationContext>();
                    DataDbInitializer.AuthSeed(AuthenticationContext);
                    AuthenticationContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
