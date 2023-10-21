using FluentValidation;

namespace OskiFSPY.Core.UsersTestsStatuses.Get;

public class GetUserTestQueryValidator : AbstractValidator<GetUserTestQuery>
{
    public GetUserTestQueryValidator()
    {
        RuleFor(query => query).NotEmpty();
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}
