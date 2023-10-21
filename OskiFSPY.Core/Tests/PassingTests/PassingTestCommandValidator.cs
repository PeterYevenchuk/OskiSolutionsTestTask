using FluentValidation;

namespace OskiFSPY.Core.Tests.PassingTests;

public class PassingTestCommandValidator : AbstractValidator<PassingTestCommand>
{
    public PassingTestCommandValidator()
    {
        RuleFor(query => query.UserId).GreaterThan(0);
        RuleFor(query => query.TestId).GreaterThan(0);
        RuleFor(query => query.QuestionAndAnswer).NotNull().NotEmpty();
    }
}
