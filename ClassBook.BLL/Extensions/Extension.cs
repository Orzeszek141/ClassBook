using ClassBook.BLL.IServices;
using ClassBook.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClassBook.BLL.Extensions;

public static class Extension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFacultyService, FacultyService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IUserInfoService, UserInfoService>();

        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}