using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyResturants.Domain.Entities;

namespace MyResturants.Infrastructure.Presistance;

internal class ResturantsDbContext : IdentityDbContext<User>
{
    public ResturantsDbContext(DbContextOptions<ResturantsDbContext> options) : base(options)
    {
    }

    internal DbSet<Resturant> Resturants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Leave it Very Imortant or u will face issues like 'The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating

        modelBuilder.Entity<Resturant>().OwnsOne(r => r.Address);

        modelBuilder.Entity<Resturant>()
            .HasMany(r => r.Dishes)
            .WithOne(d => d.Resturant)
            .HasForeignKey(d => d.ResturantId);

        modelBuilder.Entity<Dish>()
           .Property(d => d.Price)
           .HasPrecision(18, 2);

        modelBuilder.Entity<User>()
            .HasMany(u => u.OwnedResturants)
            .WithOne(r => r.Owner).HasForeignKey(r => r.OwnerId);
    }
}