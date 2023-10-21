using OskiFSPY.Core.Questions;

namespace OskiFSPY.Core.Answers;

public class AnswerResponse
{
    public int AnswerId { get; set; }

    public string AnswerText { get; set; }

    public int QuestionId { get; set; }

    public Question Question { get; set; }
}
