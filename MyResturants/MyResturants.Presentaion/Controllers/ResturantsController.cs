using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyResturants.Application.Resturants;
using MyResturants.Application.Resturants.Dtos;
using MyResturants.Domain.Entities;

namespace MyResturants.Presentaion.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResturantsController(IResturantsService resturantsService) 
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Resturant>>> GetAll()
    {
        var resturants = await resturantsService.GetAllAsync();
        return Ok(resturants);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Resturant>> GetById([FromRoute] int id)
    {
        var resturant = await resturantsService.GetByIdAsync(id);

        if(resturant is null) return NotFound();

        return Ok(resturant);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateResturantDto createResturantDto)
    {
        int id = await resturantsService.CreateAsync(createResturantDto);
        return CreatedAtAction(nameof(GetById), new { id = id }, null);
    }
}