using OskiFSPY.Core.Questions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.Answers;

public class Answer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnswerId { get; set; }

    public string AnswerText { get; set; }

    public bool RightAnswer { get; set; }

    public int QuestionId { get; set; }

    [ForeignKey("QuestionId")]
    public Question Question { get; set; }
}
