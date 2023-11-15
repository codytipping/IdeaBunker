using IdeaBunker.Data;

namespace IdeaBunker;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("app");
            var identityContext = services.GetRequiredService<Context>();
            try
            {  
                // Insert Seed Data for users and roles.
                logger.LogInformation("Finished Seeding Default Data");
                logger.LogInformation("Application Starting");
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "An error occurred seeding the DB");
            }
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}