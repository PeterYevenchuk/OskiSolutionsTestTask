using OskiFSPY.Core.Tests;
using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.Questions;

public class Question
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuestionId { get; set; }

    public string QuestionText { get; set; }

    public int Points { get; set; }

    public int TestId { get; set; }

    [ForeignKey("TestId")]
    public Test Test { get; set; }
}
