using OskiFSPY.Core.Helpers.PasswordHasher;
using MediatR;
using Microsoft.Extensions.Configuration;
using OskiFSPY.Core.AuthJWT;
using OskiFSPY.Core.Context;

namespace OskiFSPY.Core.AuthJWTHelper;

public class JwtCommandHandler : IRequestHandler<JwtCommand, Tokens>
{
    private readonly OskiTestTaskContext _context;
    private readonly string _jwtApiKey;
    private readonly IPasswordHash _hasher;

    public JwtCommandHandler(OskiTestTaskContext cookFitContext, IConfiguration configuration, IPasswordHash passwordHash)
    {
        _context = cookFitContext;
        _hasher = passwordHash;
        _jwtApiKey = configuration.GetValue<string>("JWTSettings:ApiKey");
    }

    public Task<Tokens> Handle(JwtCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var user = _context.Users.FirstOrDefault(a => a.Email == request.Email);
        if (user is null)
        {
            throw new InvalidDataException("Wrong credentials!");
        }

        var passwordHash = _hasher.EncryptPassword(request.Password, Convert.FromBase64String(user.Salt));

        if (user.Password == passwordHash)
        {
            var accessToken = TokenUtilities.CreateToken(user, _jwtApiKey);
            var refreshToken = TokenUtilities.GenerateRefreshToken();

            RefreshTokenStorage.AddOrUpdateRefreshToken(user.UserId, refreshToken);

            var tokens = new Tokens
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return Task.FromResult(tokens);
        }
        else
        {
            throw new InvalidDataException("Wrong credentials!");
        }
    }
}
