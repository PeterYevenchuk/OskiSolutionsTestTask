using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OskiFSPY.Core.Context;

namespace OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

public class GetUserIsPassedTestQueryHandler : IRequestHandler<GetUserIsPassedTestQuery, List<UserResponse>>
{
    private readonly OskiTestTaskContext _context;
    private readonly IMapper _mapper;

    public GetUserIsPassedTestQueryHandler(OskiTestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserResponse>> Handle(GetUserIsPassedTestQuery request, CancellationToken cancellationToken)
    {
        var myTests = await _context.UserTestStatuses
            .Where(uts => uts.UserId == request.UserId && uts.Passed == request.Passed)
            .Include(uts => uts.Test)
            .ToListAsync();

        if (myTests.IsNullOrEmpty())
        {
            return null;
        }

        var myTestStatus = myTests.Select(uts => _mapper.Map<UserResponse>(uts)).ToList();

        return myTestStatus;
    }
}
