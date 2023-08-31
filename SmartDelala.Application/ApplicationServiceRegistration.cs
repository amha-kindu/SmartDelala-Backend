using Serilog;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SmartDelala.Application.Profiles;
using SmartDelala.Application.Contracts.Persistence;
using AutoMapper;

namespace SmartDelala.Application;
public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Serilog logging
        Log.Logger = new LoggerConfiguration()
            // .MinimumLevel.Debug()
            .MinimumLevel.Information()
            .WriteTo.File("Log/SmartDelalaErrorLog.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();

        services.AddScoped<IMapper>(
            provider => {
                var unitOfWork = provider.GetRequiredService<IUnitOfWork>();

                var profile = new MappingProfile();
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(profile);
                });
                return configuration.CreateMapper();
            }
        );
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
