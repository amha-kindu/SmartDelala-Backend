using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SmartDelala.Persistence;

public class SmartDelalaDbContextFactory: IDesignTimeDbContextFactory<SmartDelalaDbContext>
{
    public SmartDelalaDbContext CreateDbContext(string[] args) 
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()+"/../SmartDelala.WebApi/")
                .AddJsonFile("appsettings.json")
                .Build();

        var builder = new DbContextOptionsBuilder<SmartDelalaDbContext>();
        var connectionString = configuration.GetConnectionString("SmartDelalaConnectionString");

        builder.UseNpgsql(connectionString);

        return new SmartDelalaDbContext(builder.Options);
    }
}