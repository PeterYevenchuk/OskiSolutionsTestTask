using System.ComponentModel.DataAnnotations.Schema;

namespace OskiFSPY.Core.Tests;

public class Test
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TestId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
