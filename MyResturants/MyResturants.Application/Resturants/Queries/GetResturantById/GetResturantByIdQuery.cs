using MediatR;
using MyResturants.Application.Resturants.Dtos;

namespace MyResturants.Application.Resturants.Queries.GetResturantById;

public class GetResturantByIdQuery(int id) : IRequest<ResturantDto>
{
    public int Id { get; } = id;
}