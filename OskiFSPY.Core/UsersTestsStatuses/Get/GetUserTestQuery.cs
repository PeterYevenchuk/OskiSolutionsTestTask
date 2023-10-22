using MediatR;

namespace OskiFSPY.Core.UsersTestsStatuses.Get;

public class GetUserTestQuery : IRequest<List<UserTestStatusResponse>>
{
    public int UserId { get; set; }
}
