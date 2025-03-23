using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;
using MyResturants.Infrastructure.Presistance;
using MyResturants.Infrastructure.Repositories;
using MyResturants.Infrastructure.Seeders;

namespace MyResturants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ResturantsDb");

        services.AddDbContext<ResturantsDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<ResturantsDbContext>();

        services.AddScoped<IResturantSeeder, ResturantSeeder>();

        services.AddScoped<IResturantRepository, ResturantRepositoy>();
        services.AddScoped<IDishRepository, DishRepository>();
    }
}