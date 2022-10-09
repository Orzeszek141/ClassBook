using ClassBook.Api.Extensions;
using ClassBook.BLL.Extensions;
using ClassBook.DAL;
using ClassBook.DAL.Extensions;
using FluentValidation.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(context.Configuration));

    builder.Services.AddMiddleware();
    builder.Services.AddRepositories();
    builder.Services.AddServices();
    builder.Services.AddMapper();
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddValidator();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddMyDbContext(builder.Configuration);
    builder.Services.AddAuth(builder.Configuration);

    var app = builder.Build();

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    app.UseMiddleware();
    app.Services.PerformDatabaseUpdate();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetService<MyDbContext>();
        Seeder.SeedData(context);
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuth();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

