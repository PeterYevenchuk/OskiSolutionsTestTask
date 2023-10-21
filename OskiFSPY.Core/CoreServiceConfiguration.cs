using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OskiFSPY.Core.Context;
using OskiFSPY.Core.Helpers.PasswordHasher;
using OskiFSPY.Core.ValidationBehaviors;

namespace OskiFSPY.Core;

public static class CoreServiceConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CoreServiceConfiguration).Assembly))
            .AddAutoMapper(typeof(CoreMappingsProfile).Assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(typeof(CoreServiceConfiguration).Assembly)
            .AddDbContext<OskiTestTaskContext>()
            .AddScoped<IPasswordHash, PasswordHash>();
    }
}
