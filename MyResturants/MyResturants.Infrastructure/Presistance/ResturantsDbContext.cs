using Microsoft.EntityFrameworkCore;
using MyResturants.Domain.Entities;

namespace MyResturants.Infrastructure.Presistance;

public class ResturantsDbContext : DbContext
{
    public DbSet<Resturant> Resturants { get; set; }
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseSqlServer("Server=.;Database=MyResturantsDb;Trusted_Connection=True;Trust Server Certificate=True;MultipleActiveResultSets=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturant>().OwnsOne(r => r.Address, a =>
        {
            //a.Property(a => a.Street).IsRequired();
        });


        modelBuilder.Entity<Resturant>()
            .HasMany(r => r.Dishes).WithOne(d => d.Resturant)
            .HasForeignKey(d => d.RestaurantId);

        modelBuilder.Entity<Dish>()
           .Property(d => d.Price)
           .HasPrecision(18, 2);  

    }
}
