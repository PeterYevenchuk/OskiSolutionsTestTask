using OskiFSPY.Core.Tests;
using OskiFSPY.Core.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.UsersTestsStatuses;

public class UserTestStatus
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserTestStatusId { get; set; }

    public bool Passed { get; set; }

    public int Rating { get; set; }

    public int? UserId { get; set; }

    public int? TestId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("TestId")]
    public Test Test { get; set; }
}
