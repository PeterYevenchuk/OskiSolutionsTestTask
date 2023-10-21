using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OskiFSPY.Core.Context;

namespace OskiFSPY.Core.AuthJWT.RefreshJWT;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Tokens>
{
    private readonly OskiTestTaskContext _context;
    private readonly string _jwtApiKey;

    public RefreshTokenCommandHandler(OskiTestTaskContext cookFitContext, IConfiguration configuration)
    {
        _context = cookFitContext;
        _jwtApiKey = configuration.GetValue<string>("JWTSettings:ApiKey");
    }

    public async Task<Tokens> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(a => a.UserId == request.UserId);

        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (user == null)
        {
            return null;
        }

        var storedRefreshToken = RefreshTokenStorage.GetRefreshToken(user.UserId);

        if (storedRefreshToken != request.RefreshToken)
        {
            return null;
        }

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtApiKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var claimsPrincipal = tokenHandler.ValidateToken(request.AccessToken, tokenValidationParameters, out _);

        if (!(claimsPrincipal.Identity is ClaimsIdentity claimsIdentity) ||
            !claimsIdentity.IsAuthenticated ||
            claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value != user.UserId.ToString())
        {
            return null;
        }

        var refreshToken = TokenUtilities.GenerateRefreshToken();
        RefreshTokenStorage.AddOrUpdateRefreshToken(user.UserId, refreshToken);

        await _context.SaveChangesAsync();

        var tokens = new Tokens
        {
            AccessToken = TokenUtilities.CreateToken(user, _jwtApiKey),
            RefreshToken = refreshToken,
        };

        return tokens;
    }
}
