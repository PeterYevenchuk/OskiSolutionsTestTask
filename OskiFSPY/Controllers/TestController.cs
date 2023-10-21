using MediatR;
using Microsoft.AspNetCore.Mvc;
using OskiFSPY.Core.Tests.Get;

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

    [HttpGet("{testId}")]
    public async Task<IActionResult> GetTest(int testId)
    {
        var query = new GetFullTestQuery { TestId = testId };
        var result = await _mediator.Send(query);

        return result == null
        ? NotFound("Not found!")
        : Ok(result);
    }
}
