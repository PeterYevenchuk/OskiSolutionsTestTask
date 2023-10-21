using OskiFSPY.Core.Tests;

namespace OskiFSPY.Core.UsersTestsStatuses;

public class UserResponse
{
    public bool Passed { get; set; }

    public int Rating { get; set; }

    public int? UserId { get; set; }

    public Test Test { get; set; }
}
