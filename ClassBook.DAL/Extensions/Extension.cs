using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassBook.DAL.Extensions;

public static class Extension
{
    public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));

        return services;
    }

    public static IServiceProvider PerformDatabaseUpdate(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dataContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        dataContext.Database.Migrate();
        return services;
    }
}