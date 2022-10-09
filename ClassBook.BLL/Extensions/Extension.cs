using System.Reflection;
using ClassBook.BLL.Authorization.PasswordHashers;
using ClassBook.BLL.IServices;
using ClassBook.BLL.Services;
using ClassBook.BLL.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClassBook.BLL.Extensions;

public static class Extension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFacultyService, FacultyService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }

    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(ClassAddValidator));

        return services;
    }
}