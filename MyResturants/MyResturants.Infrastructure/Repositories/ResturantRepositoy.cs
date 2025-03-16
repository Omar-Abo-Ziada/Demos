using Microsoft.EntityFrameworkCore;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;
using MyResturants.Infrastructure.Presistance;

namespace MyResturants.Infrastructure.Repositories;

internal class ResturantRepositoy(ResturantsDbContext context) : IResturantRepository
{
    public async Task<IEnumerable<Resturant>> GetAllAsync()
    {
        return await context.Resturants.ToListAsync();
    }
}