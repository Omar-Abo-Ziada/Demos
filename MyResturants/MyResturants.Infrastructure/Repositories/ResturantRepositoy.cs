using Microsoft.EntityFrameworkCore;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;
using MyResturants.Infrastructure.Presistance;

namespace MyResturants.Infrastructure.Repositories;

internal class ResturantRepositoy(ResturantsDbContext context) : IResturantRepository
{
    public async Task<int> CreateAsync(Resturant resturant)
    {
        await context.AddAsync(resturant);
        await context.SaveChangesAsync();
        return resturant.Id;
    }

    public async Task Delete(Resturant resturant)
    {
        context.Resturants.Remove(resturant);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Resturant>> GetAllAsync()
    {
        return await context.Resturants.ToListAsync();
    }

    public async Task<Resturant?> GetByIdAsync(int id)
    {
        return await context.Resturants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}