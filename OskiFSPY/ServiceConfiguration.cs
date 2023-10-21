using MediatR;
using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Context;
using System.Reflection;

namespace OskiFSPY.WebAPI;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        services.AddDbContext<OskiTestTaskContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("SqlConnectionString"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("OskiFSPY.WebAPI");
                });
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
