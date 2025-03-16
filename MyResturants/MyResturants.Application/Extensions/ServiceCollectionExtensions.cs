using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyResturants.Application.Resturants;
using Serilog;

namespace MyResturants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IResturantsService, ResturantsService>();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Seq("http://localhost:5341/")
            .CreateLogger();

        services.AddSerilog();
    }
}