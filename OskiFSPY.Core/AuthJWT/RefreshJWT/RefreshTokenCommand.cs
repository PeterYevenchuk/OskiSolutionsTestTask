using MediatR;

namespace OskiFSPY.Core.AuthJWT.RefreshJWT;

public class RefreshTokenCommand : IRequest<Tokens>
{
    public int UserId { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}
