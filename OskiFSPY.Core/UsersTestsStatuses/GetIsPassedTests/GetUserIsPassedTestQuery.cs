using MediatR;
using OskiFSPY.Core.UsersTestsStatuses.Get;

namespace OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

public class GetUserIsPassedTestQuery : IRequest<List<UserTest>>
{
    public int UserId { get; set; }

    public bool Passed { get; set; }
}
