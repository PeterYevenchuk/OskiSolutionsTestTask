using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core.Tests.PassingTests;

public class PassingTestCommandHandler : IRequestHandler<PassingTestCommand, UserTestStatusResponse>
{
    private readonly OskiTestTaskContext _context;
    private readonly IMapper _mapper;

    public PassingTestCommandHandler(OskiTestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserTestStatusResponse> Handle(PassingTestCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);

        if (user == null)
        {
            throw new ArgumentException("User not found!");
        }

        var test = await _context.Tests.FirstOrDefaultAsync(t => t.TestId == request.TestId && t.UserId == user.UserId);

        if (test != null && test.Passed == true)
        {
            throw new ArgumentException("You have already passed this test!");
        }
        else if (test == null)
        {
            throw new ArgumentException("Test not found!");
        }

        var questions = await _context.Questions
            .Where(q => q.TestId == test.TestId)
            .ToListAsync();

        var maxPoints = questions.Sum(q => q.Points);

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
            Rating = totalScore,
            TestId = test.TestId,
            Test = test
        };

        _context.UserTestStatuses.Add(userTestStatus);

        test.Passed = true;
        test.UserId = user.UserId;
        test.User = user;

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        var myTestStatus = _mapper.Map<UserTestStatusResponse>(userTestStatus);

        myTestStatus.MaxRaiting = maxPoints;
        myTestStatus.TestResponse = _mapper.Map<TestResponse>(test);

        return myTestStatus;
    }
}
