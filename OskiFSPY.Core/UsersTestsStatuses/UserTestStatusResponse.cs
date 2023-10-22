using OskiFSPY.Core.Tests;

namespace OskiFSPY.Core.UsersTestsStatuses;

public class UserTestStatusResponse
{
    public int? Rating { get; set; }

    public int? MaxRaiting { get; set; }

    public TestResponse? TestResponse { get; set; }
}
