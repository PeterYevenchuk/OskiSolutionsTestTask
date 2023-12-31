﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.Questions;

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

        var fullTest = new FullTest
        {
            TestResponse = _mapper.Map<TestResponse>(test),
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
                QuestionResponse = _mapper.Map<QuestionResponse>(question),
                Answers = _mapper.Map<List<AnswerResponse>>(answers)
            };

            fullTest.Questions.Add(questionWithAnswers);
        }

        return fullTest;
    }
}
