using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Context;

namespace OskiFSPY.Core.Tests.Get;

public class GetFullTestQueryHandler : IRequestHandler<GetFullTestQuery, FullTest>
{
    private readonly OskiTestTaskContext _context;
    private readonly IMapper _mapper;

    public GetFullTestQueryHandler(OskiTestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FullTest> Handle(GetFullTestQuery request, CancellationToken cancellationToken)
    {
        var test = await _context.Tests.FirstOrDefaultAsync(t => t.TestId == request.TestId);

        if (test == null)
        {
            return null;
        }

        var fullTest = new FullTest
        {
            Test = test,
            Questions = new List<QuestionWithAnswers>()
        };

        var questions = await _context.Questions
            .Where(q => q.TestId == test.TestId)
            .ToListAsync();

        foreach (var question in questions)
        {
            var answers = await _context.Answers
                .Where(a => a.QuestionId == question.QuestionId)
                .ToListAsync();

            var questionWithAnswers = new QuestionWithAnswers
            {
                Question = question,
                Answers = _mapper.Map<List<AnswerResponse>>(answers)
            };

            fullTest.Questions.Add(questionWithAnswers);
        }

        return fullTest;
    }
}
