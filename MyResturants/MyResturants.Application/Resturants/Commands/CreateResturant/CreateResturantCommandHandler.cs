using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Repositories;

namespace MyResturants.Application.Resturants.Commands.CreateResturant;

public class CreateResturantCommandHandler(ILogger<CreateResturantCommandHandler> logger , IMapper mapper , 
    IResturantRepository resturantRepository)
    : IRequestHandler<CreateResturantCommand, int>
{
    public async Task<int> Handle(CreateResturantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating New Resturant");
        var resturant = mapper.Map<Resturant>(request);
        int id = await resturantRepository.CreateAsync(resturant);
        return id;
    }
}