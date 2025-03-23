using Microsoft.OpenApi.Models;
using MyResturants.Application.Extensions;
using MyResturants.Domain.Entities;
using MyResturants.Infrastructure.Extensions;
using MyResturants.Infrastructure.Seeders;
using MyResturants.Presentaion.Extensions;
using MyResturants.Presentaion.Middlewares;
using Serilog;

namespace MyResturants.Presentaion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddPresentaion();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication(builder.Configuration);

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IResturantSeeder>();
            await seeder.Seed();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Resturants API v1"));
            }

            app.UseHttpsRedirection();

            app.MapGroup("api/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
