using FluentValidation;

namespace OskiFSPY.Core.AuthJWT.AccessToken;

public class JwtCommandValidator : AbstractValidator<JwtCommand>
{
    public JwtCommandValidator()
    {
        RuleFor(query => query.Email).NotNull().NotEmpty();
        RuleFor(query => query.Password).NotNull().NotEmpty();
    }
}
