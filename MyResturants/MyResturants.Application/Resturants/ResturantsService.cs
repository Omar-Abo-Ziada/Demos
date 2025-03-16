using Microsoft.Extensions.Logging;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;

namespace MyResturants.Application.Resturants;

internal class ResturantsService(IResturantRepository resturantRepository , 
    ILogger<ResturantsService> logger) 
    : IResturantsService
{
    public async Task<IEnumerable<Resturant>> GetAllAsync()
    {
        logger.LogInformation("GetAllAsync called");
        return await resturantRepository.GetAllAsync();
    }
}