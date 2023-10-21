using FluentValidation;

namespace OskiFSPY.Core.AuthJWTHelper;

public class JwtCommandValidator : AbstractValidator<JwtCommand>
{
    public JwtCommandValidator()
    {
        RuleFor(query => query.Email).NotNull().NotEmpty();
        RuleFor(query => query.Password).MinimumLength(8);
    }
}
