using MediatR;

namespace OskiFSPY.Core.UsersTestsStatuses.Get;

public class GetUserTestQuery : IRequest<List<UserTest>>
{
    public int UserId { get; set; }
}
