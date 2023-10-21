using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core.Tests.PassingTests;

public class PassingTestCommandHandler : IRequestHandler<PassingTestCommand, UserResponse>
{
    private readonly OskiTestTaskContext _context;
    private readonly IMapper _mapper;

    public PassingTestCommandHandler(OskiTestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(PassingTestCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
        var test = await _context.Tests.FirstOrDefaultAsync(t => t.TestId == request.TestId);

        if (test == null || user == null)
        {
            return null;
        }

        var existingStatus = await _context.UserTestStatuses
                .FirstOrDefaultAsync(uts => uts.UserId == user.UserId && uts.TestId == test.TestId);

        if (existingStatus != null && existingStatus.Passed == true)
        {
            throw new ArgumentException("You have already passed this test!");
        }

        var questions = await _context.Questions
            .Where(q => q.TestId == test.TestId)
            .ToListAsync();

        var totalScore = 0;

        foreach (var question in questions)
        {
            var answers = await _context.Answers
                .Where(a => a.QuestionId == question.QuestionId)
                .ToListAsync();

            if (request.QuestionAndAnswer.TryGetValue(question.QuestionId, out var userAnswerId))
            {
                var correctAnswer = answers.FirstOrDefault(a => a.RightAnswer);

                if (correctAnswer != null && correctAnswer.AnswerId == userAnswerId)
                {
                    totalScore += question.Points;
                }
            }
        }

        using var transaction = _context.Database.BeginTransaction();
        var userTestStatus = new UserTestStatus
        {
            Passed = true,
            Rating = totalScore,
            UserId = user.UserId,
            TestId = test.TestId,
            User = user,
            Test = test
        };

        _context.UserTestStatuses.Add(userTestStatus);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        var myTestStatus = _mapper.Map<UserResponse>(userTestStatus);

        return myTestStatus;
    }
}
