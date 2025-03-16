using MyResturants.Domain.Entities;

namespace MyResturants.Application.Resturants;

public interface IResturantsService
{
    Task<IEnumerable<Resturant>> GetAllAsync();
}