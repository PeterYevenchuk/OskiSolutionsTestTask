using AutoMapper;
using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Questions;
using OskiFSPY.Core.Tests;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core;

public class CoreMappingsProfile : Profile
{
    public CoreMappingsProfile()
    {
        CreateMap<UserTestStatus, UserTestStatusResponse>();

        CreateMap<Answer, AnswerResponse>();

        CreateMap<Question, QuestionResponse>();

        CreateMap<Test, TestResponse>();
    }
}
