using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MimirCore.Application.Infrastructure;
using MimirCore.Infrastructure.Persistance;

namespace MimirCore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database Configuration
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString, b => 
            {
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                b.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
            
            // Enable sensitive data logging in development
            var enableSensitiveDataLogging = configuration.GetSection("Database")["EnableSensitiveDataLogging"];
            if (bool.TryParse(enableSensitiveDataLogging, out bool enableSensitive) && enableSensitive)
            {
                options.EnableSensitiveDataLogging();
            }
            
            // Enable detailed errors in development
            var enableDetailedErrors = configuration.GetSection("Database")["EnableDetailedErrors"];
            if (bool.TryParse(enableDetailedErrors, out bool enableDetailed) && enableDetailed)
            {
                options.EnableDetailedErrors();
            }
        });

        // Database Initializer
        services.AddScoped<ApplicationDbContextInitializer>();

        // Application Interfaces
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        // Caching
        services.AddMemoryCache();

        // Note: Additional infrastructure services (Email, FileStorage, etc.) and 
        // background services will be added when their implementations are created

        return services;
    }
}