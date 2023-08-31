using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using SmartDelala.Infrastructure.Security;
using SmartDelala.Infrastructure.Services;
using SmartDelala.Application.Features.User;
using Microsoft.Extensions.DependencyInjection;
using SmartDelala.Application.Contracts.Services;

namespace SmartDelala.Infrastructure;

public  static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        Account account = new Account(
            configuration["Cloudinary:CloudName"],
            configuration["Cloudinary:ApiKey"],
            configuration["Cloudinary:ApiSecret"]
        );
        services.AddSingleton(new Cloudinary(account));
        services.AddScoped<IResourceManager, ResourceManager>();
        services.AddScoped<IUserAccessor, UserAccessor>();
        return services;
    }
}
