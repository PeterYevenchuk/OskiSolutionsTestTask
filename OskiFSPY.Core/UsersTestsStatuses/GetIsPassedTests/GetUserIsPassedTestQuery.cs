using MediatR;

namespace OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

public class GetUserIsPassedTestQuery : IRequest<List<UserTestStatusResponse>>
{
    public int UserId { get; set; }

    public bool Passed { get; set; }
}
