using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Questions;

namespace OskiFSPY.Core.Tests;

public class QuestionWithAnswers
{
    public QuestionResponse QuestionResponse { get; set; }

    public List<AnswerResponse> Answers { get; set; }
}
