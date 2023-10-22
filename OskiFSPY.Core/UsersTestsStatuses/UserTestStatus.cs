using OskiFSPY.Core.Tests;
using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.UsersTestsStatuses;

public class UserTestStatus
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserTestStatusId { get; set; }

    public int Rating { get; set; }

    public int? TestId { get; set; }

    [ForeignKey("TestId")]
    public Test Test { get; set; }
}
