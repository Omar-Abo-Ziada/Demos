using Microsoft.EntityFrameworkCore;
using MyResturants.Domain.Entities;

namespace MyResturants.Infrastructure.Presistance;

internal class ResturantsDbContext(DbContextOptions<ResturantsDbContext> options) : DbContext(options)
{
    internal DbSet<Resturant> Resturants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturant>().OwnsOne(r => r.Address);

        modelBuilder.Entity<Resturant>()
            .HasMany(r => r.Dishes).WithOne(d => d.Resturant)
            .HasForeignKey(d => d.RestaurantId);

        modelBuilder.Entity<Dish>()
           .Property(d => d.Price)
           .HasPrecision(18, 2);  
    }
}