using MyResturants.Domain.Entities;

namespace MyResturants.Domain.Repositories;

public interface IResturantRepository
{
    Task<int> CreateAsync(Resturant resturant);
    public Task<IEnumerable<Resturant>> GetAllAsync();
    public Task<Resturant?> GetByIdAsync(int id);
}