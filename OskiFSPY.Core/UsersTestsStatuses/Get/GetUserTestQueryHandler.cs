using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OskiFSPY.Core.Context;

namespace OskiFSPY.Core.UsersTestsStatuses.Get;

public class GetUserTestQueryHandler : IRequestHandler<GetUserTestQuery, List<UserTest>>
{
    private readonly OskiTestTaskContext _context;
    private readonly IMapper _mapper;

    public GetUserTestQueryHandler(OskiTestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserTest>> Handle(GetUserTestQuery request, CancellationToken cancellationToken)
    {
        var myTests = await _context.UserTestStatuses
            .Where(uts => uts.UserId == request.UserId)
            .Include(uts => uts.Test)
            .ToListAsync();

        if (myTests.IsNullOrEmpty())
        {
            return null;
        }

        var myTestStatus = myTests.Select(uts => _mapper.Map<UserTest>(uts)).ToList();

        return myTestStatus;
    }
}
