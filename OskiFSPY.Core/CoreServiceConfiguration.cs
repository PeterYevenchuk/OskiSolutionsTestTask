using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OskiFSPY.Core;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.ValidationBehaviors;

namespace CookFit.Core;

public static class CoreServiceConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CoreServiceConfiguration).Assembly))
            .AddAutoMapper(typeof(CoreMappingsProfile).Assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(typeof(CoreServiceConfiguration).Assembly)
            .AddDbContext<OskiTestTaskContext>();

    }
}
