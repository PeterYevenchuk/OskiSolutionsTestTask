using OskiFSPY.Core.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.Tests;

public class Test
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TestId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool Passed { get; set; }

    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
