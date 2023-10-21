﻿using MediatR;
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

    [HttpGet("{testId}/{userId}")]
    public async Task<IActionResult> GetTest(int testId, int userId)
    {
        var query = new GetFullTestQuery { TestId = testId, UserId = userId };
        var result = await _mediator.Send(query);

        return result == null
        ? NotFound("Not found!")
        : Ok(result);
    }

    [HttpPost("passing-test")]
    public async Task<IActionResult> PassingTest(PassingTestCommand query)
    {
        var result = await _mediator.Send(query);

        return result == null
        ? NotFound("User or Test not found!")
        : Ok(result);
    }
}
