using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyResturants.Domain.Repositories;

namespace MyResturants.Application.Resturants.Commands.UpdateResturant;

public class UpdateResturantCommandHandler
    (ILogger<UpdateResturantCommand> logger, IMapper mapper, IResturantRepository resturantRepository)
    : IRequestHandler<UpdateResturantCommand, bool>
{
    public async Task<bool> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating Resturant With Id : {request.Id}");

        var resturant = await resturantRepository.GetByIdAsync(request.Id);
        if (resturant is null) return false;

        mapper.Map(request, resturant);

        await resturantRepository.UpdateAsync(resturant);
        return true;
    }
}