using FluentValidation;

namespace OskiFSPY.Core.Tests.Get;

public class GetFullTestQueryValidator : AbstractValidator<GetFullTestQuery>
{
    public GetFullTestQueryValidator()
    {
        RuleFor(query => query.TestId).GreaterThan(0);
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}
