using MediatR;
using OskiFSPY.Core.AuthJWT;

namespace OskiFSPY.Core.AuthJWT.AccessToken;

public class JwtCommand : IRequest<Tokens>
{
    public string Email { get; set; }

    public string Password { get; set; }
}
