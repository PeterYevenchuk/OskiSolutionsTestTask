using FluentValidation;

namespace OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

public class GetUserIsPassedTestQueryValidator : AbstractValidator<GetUserIsPassedTestQuery>
{
    public GetUserIsPassedTestQueryValidator()
    {
        RuleFor(query => query).NotEmpty();
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}
