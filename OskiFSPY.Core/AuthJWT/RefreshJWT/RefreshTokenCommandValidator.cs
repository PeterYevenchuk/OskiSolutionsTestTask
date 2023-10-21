using FluentValidation;

namespace OskiFSPY.Core.AuthJWT.RefreshJWT;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(query => query.UserId).NotNull().NotEmpty();
        RuleFor(query => query.AccessToken).NotNull().NotEmpty();
        RuleFor(query => query.RefreshToken).NotNull().NotEmpty();
    }
}
