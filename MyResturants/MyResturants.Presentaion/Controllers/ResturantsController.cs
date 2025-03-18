using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyResturants.Application.Resturants.Commands.CreateResturant;
using MyResturants.Application.Resturants.Commands.DeleteResturant;
using MyResturants.Application.Resturants.Queries.GetAllResturants;
using MyResturants.Application.Resturants.Queries.GetResturantById;
using MyResturants.Domain.Entities;

namespace MyResturants.Presentaion.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResturantsController(/*IResturantsService resturantsService ,*/ IMediator mediator) 
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Resturant>>> GetAll()
    {
        //var resturants = await resturantsService.GetAllAsync();
        var resturants = await mediator.Send(new GetAllResturantsQuery());
        return Ok(resturants);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Resturant>> GetById([FromRoute] int id)
    {
        //var resturant = await resturantsService.GetByIdAsync(id);
        var resturant = await mediator.Send(new GetResturantByIdQuery(id));

        if (resturant is null) return NotFound();

        return Ok(resturant);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Resturant>> Delete([FromRoute] int id)
    {
        //var resturant = await resturantsService.GetByIdAsync(id);
        bool isDeleted = await mediator.Send(new DeleteResturantCommand(id));

        if (!isDeleted) return NotFound();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateResturantCommand createResturantCommand)
    {
        //int id = await resturantsService.CreateAsync(createResturantDto);
        int id = await mediator.Send(createResturantCommand);
        return CreatedAtAction(nameof(GetById), new { id = id }, null);
    }
}