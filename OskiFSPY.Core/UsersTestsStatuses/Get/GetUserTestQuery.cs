using MediatR;

namespace OskiFSPY.Core.UsersTestsStatuses.Get;

public class GetUserTestQuery : IRequest<List<UserResponse>>
{
    public int UserId { get; set; }
}
