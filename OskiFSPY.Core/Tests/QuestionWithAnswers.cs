using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Questions;

namespace OskiFSPY.Core.Tests;

public class QuestionWithAnswers
{
    public Question Question { get; set; }

    public List<AnswerResponse> Answers { get; set; }
}
