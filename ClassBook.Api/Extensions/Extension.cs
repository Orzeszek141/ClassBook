using ClassBook.Api.Middlewares;

namespace ClassBook.Api.Extensions;

public static class Extension
{
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();

        return services;
    }

    public static WebApplication UseMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
            
        return app;
    }
}