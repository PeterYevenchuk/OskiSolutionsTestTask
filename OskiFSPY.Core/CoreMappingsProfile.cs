using AutoMapper;
using OskiFSPY.Core.Answers;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core;

public class CoreMappingsProfile : Profile
{
    public CoreMappingsProfile()
    {
        CreateMap<UserTestStatus, UserResponse>();

        CreateMap<Answer, AnswerResponse>();
    }
}
