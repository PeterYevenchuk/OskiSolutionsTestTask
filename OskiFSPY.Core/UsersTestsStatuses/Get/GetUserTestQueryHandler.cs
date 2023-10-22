using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.Tests;

namespace OskiFSPY.Core.UsersTestsStatuses.Get
{
    public class GetUserTestQueryHandler : IRequestHandler<GetUserTestQuery, List<UserTestStatusResponse>>
    {
        private readonly OskiTestTaskContext _context;
        private readonly IMapper _mapper;

        public GetUserTestQueryHandler(OskiTestTaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserTestStatusResponse>> Handle(GetUserTestQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found!");
            }

            var userTests = await _context.Tests.Where(t => t.UserId == request.UserId).ToListAsync();
            if (userTests.Count == 0)
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
}
