using Microsoft.EntityFrameworkCore;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;
using MyResturants.Infrastructure.Presistance;

namespace MyResturants.Infrastructure.Repositories;

internal class DishRepository(ResturantsDbContext context) : IDishRepository
{
    public async Task<int> CreateAsync(Dish entity)
    {
        context.Dishes.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Dish>?> GetAllForResturantAsync(int resturantId)
    {
        return await context.Dishes
            .Where(d => d.ResturantId == resturantId)
            .ToListAsync();
    }

    public async Task RemoveAllForResturantAsync(int resturantId)
    {
        var dishes = await context.Dishes
            .Where(d => d.ResturantId == resturantId)
            .ToListAsync();
        context.Dishes.RemoveRange(dishes);
        await context.SaveChangesAsync();
    }
}