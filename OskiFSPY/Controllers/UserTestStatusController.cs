using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OskiFSPY.Core.UsersTestsStatuses.Get;
using OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

namespace OskiFSPY.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserTestStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserTestStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize(Roles = "User")]
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserTests(int userId)
    {
        var query = new GetUserTestQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return result == null
        ? NotFound("Not found!")
        : Ok(result);
    }

    //[Authorize(Roles = "User")]
    [HttpGet("is-passed/{userId}/{isPassed}")]
    public async Task<IActionResult> GetUserTests(int userId, bool isPassed)
    {
        var query = new GetUserIsPassedTestQuery { UserId = userId, Passed = isPassed };
        var result = await _mediator.Send(query);

        return result == null
        ? NotFound("Not found!")
        : Ok(result);
    }
}
