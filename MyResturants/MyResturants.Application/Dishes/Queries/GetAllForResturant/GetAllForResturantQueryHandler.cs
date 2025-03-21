﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyResturants.Application.Dishes.Dtos;
using MyResturants.Domain.Entities;
using MyResturants.Domain.Exceptions;
using MyResturants.Domain.Repositories;

namespace MyResturants.Application.Dishes.Queries.GetAllForResturant;

public class GetAllForResturantQueryHandler
    (ILogger<GetAllForResturantQueryHandler> logger, IMapper mapper,
    IResturantRepository resturantRepository, IDishRepository dishRepository)
    : IRequestHandler<GetAllForResturantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllForResturantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting All Dishes For Resturant By Id : {request.ResturantId}");

        var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
        if (resturant is null)
            throw new CustomNotFoundException(nameof(Resturant), request.ResturantId.ToString());

        // or u can just get it from the includes in the resturant repo
        //var dishes = await dishRepository.GetAllForResturantAsync(request.ResturantId);

        return mapper.Map<IEnumerable<DishDto>>(resturant.Dishes);
    }
}