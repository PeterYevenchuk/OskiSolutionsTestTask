using AutoMapper;
using OskiFSPY.Core.UsersTestsStatuses;
using OskiFSPY.Core.UsersTestsStatuses.Get;

namespace OskiFSPY.Core;

public class CoreMappingsProfile : Profile
{
    public CoreMappingsProfile()
    {
        CreateMap<UserTestStatus, UserTest>();

    }
}
