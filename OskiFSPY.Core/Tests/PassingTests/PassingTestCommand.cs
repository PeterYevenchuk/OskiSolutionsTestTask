using MediatR;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core.Tests.PassingTests;

public class PassingTestCommand : IRequest<UserTestStatusResponse>
{
    public int UserId { get; set; }

    public int TestId { get; set; }

    public Dictionary<int, int> QuestionAndAnswer { get; set; }
}
