using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartDelala.Persistence.Repositories;
using SmartDelala.Persistence.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Contracts.Persistence;

namespace SmartDelala.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SmartDelalaConnectionString");

        services.AddDbContext<SmartDelalaDbContext>(opt => {
            opt.UseNpgsql(connectionString);
        });            

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository , UserRepository>();
        
        return services;
    }
}
