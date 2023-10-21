using OskiFSPY.Core.AuthJWT.RefreshJWT;
using OskiFSPY.Core.AuthJWTHelper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        return result is null
        ? BadRequest("Login or password not correct!")
        : Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommand query)
    {
        var result = await _mediator.Send(query);

        return result is null
        ? BadRequest("Refresh token not valid or expired.")
        : Ok(result);
    }
}
