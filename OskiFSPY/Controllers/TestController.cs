using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OskiFSPY.Core.Tests.Get;
using OskiFSPY.Core.Tests.PassingTests;

namespace OskiFSPY.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "User")]
    [HttpGet("{testId}/{userId}")]
    public async Task<IActionResult> GetTest(int testId, int userId)
    {
        var query = new GetFullTestQuery { TestId = testId, UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [Authorize(Roles = "User")]
    [HttpPost("passing-test")]
    public async Task<IActionResult> PassingTest(PassingTestCommand query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
