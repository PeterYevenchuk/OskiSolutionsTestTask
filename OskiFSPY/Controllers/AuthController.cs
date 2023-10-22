using OskiFSPY.Core.AuthJWT.RefreshJWT;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OskiFSPY.Core.AuthJWT.AccessToken;

namespace OskiFSPY.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(JwtCommand query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommand query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
