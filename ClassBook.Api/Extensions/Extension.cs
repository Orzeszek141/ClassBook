using System.Text;
using ClassBook.Api.Authorization;
using ClassBook.Api.Middlewares;
using ClassBook.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

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

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtKey>(configuration.GetSection("JwtKey"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey:Key"])),
                ValidateAudience = false,
                ValidateIssuer = false
            };
        });
        services.AddAuthorization();

        return services;
    }

    public static WebApplication UseAuth(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    public static IServiceCollection AddClaims(this IServiceCollection service)
    {
        service.AddHttpContextAccessor();
        service.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        service.AddSingleton<GetUserClaim>();

        return service;
    }
}