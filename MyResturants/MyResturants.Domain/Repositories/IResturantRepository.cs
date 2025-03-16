using MyResturants.Domain.Entities;

namespace MyResturants.Domain.Repositories;

public interface IResturantRepository
{
    public Task<IEnumerable<Resturant>> GetAllAsync();
}