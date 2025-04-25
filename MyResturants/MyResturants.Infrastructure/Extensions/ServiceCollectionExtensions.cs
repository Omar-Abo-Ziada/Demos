using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;
using MyResturants.Infrastructure.Authorization;
using MyResturants.Infrastructure.Authorization.Requirements;
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
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<ResturantsUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<ResturantsDbContext>();

        services.AddScoped<IResturantSeeder, ResturantSeeder>();

        services.AddScoped<IResturantRepository, ResturantRepositoy>();
        services.AddScoped<IDishRepository, DishRepository>();

        services.AddAuthorizationBuilder()
            //.AddPolicy("HasNationality" ,builder => builder.RequireClaim("Nationality")); // will restrict to only users who has nationality in their tokens claims
            .AddPolicy(PolicyNames.HasNationality,
             builder => builder.RequireClaim(AppClaimTypes.Nationality, ["American", "French"])) // will restrict to only users who has nationality with those values in their tokens claims
           
           .AddPolicy(PolicyNames.AtLeast20,
             builder => builder.AddRequirements(new MinimumAgeRequirement(20))); // will restrict to only users who has nationality with those values in their tokens claims

        services.AddScoped<IAuthorizationHandler , MinimumAgeRequirementHandler>();
    }
}