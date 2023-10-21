using MediatR;
using Microsoft.AspNetCore.Mvc;
using OskiFSPY.Core.UsersTestsStatuses.Get;
using OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

namespace OskiFSPY.WebAPI.Controllers;

[ApiController]
public class UserTestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserTestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserTests(int userId)
    {
        var query = new GetUserTestQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return result == null
        ? NotFound("Not found!")
        : Ok(result);
    }

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
