using MediatR;

namespace MyResturants.Application.Resturants.Commands.DeleteResturant;

public class DeleteResturantCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}