using MyResturants.Application.Extensions;
using MyResturants.Infrastructure.Extensions;
using MyResturants.Infrastructure.Seeders;
using Serilog;

namespace MyResturants.Presentaion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication(builder.Configuration);

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IResturantSeeder>();
            await seeder.Seed();

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
