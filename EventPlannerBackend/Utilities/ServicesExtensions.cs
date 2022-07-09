using EventPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Utilities;

public static class ServicesExtensions
{
    private const string ConnectionStringId = "Default";
    private const string ConnectionStringErrorMessage = $"Connection string '{ConnectionStringId}' not found.";

    private static readonly InvalidOperationException ConnectionStringError = new(ConnectionStringErrorMessage);

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringId) ?? throw ConnectionStringError;
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();
        return services;
    }
}
