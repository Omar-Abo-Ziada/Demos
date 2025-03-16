using Microsoft.AspNetCore.Mvc;
using MyResturants.Application.Resturants;

namespace MyResturants.Presentaion.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResturantsController(IResturantsService resturantsService) 
    : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        var resturants = await resturantsService.GetAllAsync();
        return Ok(resturants);
    }

}