using MediatR;
using Microsoft.Extensions.Logging;
using MyResturants.Domain.Repositories;

namespace MyResturants.Application.Resturants.Commands.DeleteResturant;

public class DeleteResturantCommandHandler
    (ILogger<DeleteResturantCommandHandler> logger, IResturantRepository resturantRepository)
    : IRequestHandler<DeleteResturantCommand, bool>
{
    public async Task<bool> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting Resturant By Id : {request.Id}");

        var resturant = await resturantRepository.GetByIdAsync(request.Id);
        if (resturant is null) return false;

        await resturantRepository.Delete(resturant);
        return true;
    }
}