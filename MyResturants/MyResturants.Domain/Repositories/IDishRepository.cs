using MyResturants.Domain.Entities;

namespace MyResturants.Domain.Repositories;

public interface IDishRepository
{
    Task<int> CreateAsync(Dish entity);

    Task<IEnumerable<Dish>?> GetAllForResturantAsync(int resturantId);
}