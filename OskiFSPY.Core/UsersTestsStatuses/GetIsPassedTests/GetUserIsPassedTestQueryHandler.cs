using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.Tests;

namespace OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;

public class GetUserIsPassedTestQueryHandler : IRequestHandler<GetUserIsPassedTestQuery, List<UserTestStatusResponse>>
{
    private readonly OskiTestTaskContext _context;
    private readonly IMapper _mapper;

    public GetUserIsPassedTestQueryHandler(OskiTestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserTestStatusResponse>> Handle(GetUserIsPassedTestQuery request, CancellationToken cancellationToken)
    {
        var userTests = await _context.Tests
            .Where(uts => uts.UserId == request.UserId && uts.Passed == request.Passed)
            .ToListAsync();

        if (userTests.IsNullOrEmpty())
        {
            throw new ArgumentException("Tests not found!");
        }

        var userTestStatusResponses = new List<UserTestStatusResponse>();

        foreach (var test in userTests)
        {
            var questions = await _context.Questions
                .Where(q => q.TestId == test.TestId)
                .ToListAsync();
            var maxPoints = questions.Sum(q => q.Points);
            var testResponse = _mapper.Map<TestResponse>(test);

            var userTestStatus = await _context.UserTestStatuses.FirstOrDefaultAsync(uts => uts.TestId == test.TestId);
            var userTestStatusResponse = _mapper.Map<UserTestStatusResponse>(userTestStatus);

            if (userTestStatus == null)
            {
                userTestStatusResponse = new UserTestStatusResponse
                {
                    TestResponse = testResponse,
                    MaxRaiting = maxPoints,
                    Rating = 0
                };
            }
            else
            {
                userTestStatusResponse.TestResponse = testResponse;
                userTestStatusResponse.MaxRaiting = maxPoints;
            }

            userTestStatusResponses.Add(userTestStatusResponse);
        }

        return userTestStatusResponses;
    }
}
