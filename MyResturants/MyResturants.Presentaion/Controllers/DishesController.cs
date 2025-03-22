using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyResturants.Application.Dishes.Commands.CreateDish;
using MyResturants.Application.Dishes.Dtos;
using MyResturants.Application.Dishes.Queries.GetAllForResturant;
using MyResturants.Application.Dishes.Queries.GetDishByIdForResturant;

namespace MyResturants.Presentaion.Controllers;

[Route("api/resturants/{resturantId}/[controller]")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<IEnumerable<DishDto>>> Create([FromRoute] int resturantId, CreateDishCommand command)
    {
        command.ResturantId = resturantId;
        var id = await mediator.Send(command);
        return Created();
        //return CreatedAtAction(nameof(GetById), new { resturantId, id }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForResturant([FromRoute] int resturantId)
    {
        var dishes = await mediator.Send(new GetAllForResturantQuery(resturantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId:int}")]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetByIdResturant([FromRoute] int resturantId , [FromRoute] int dishId)
    {
        var dishes = await mediator.Send(new GetDishByIdForResturantQuery(resturantId , dishId));
        return Ok(dishes);
    }
}