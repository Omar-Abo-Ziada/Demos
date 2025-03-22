using MyResturants.Domain.Entities;

namespace MyResturants.Domain.Repositories;

public interface IResturantRepository
{
    Task<int> CreateAsync(Resturant resturant);
    Task UpdateAsync(Resturant resturant);
    Task<IEnumerable<Resturant>> GetAllAsync();
    Task<Resturant?> GetByIdAsync(int id);
    Task Delete(Resturant resturant);
}