using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyResturants.Application.Users.Commands.UpdateUserDetails;

namespace MyResturants.Presentaion.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand updateUserDetailsCommand)
    {
        await mediator.Send(updateUserDetailsCommand);
        return NoContent();
    }
}