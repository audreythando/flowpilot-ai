using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace server.Infrastructure.Persistence;

public sealed class FlowpilotDbContextFactory : IDesignTimeDbContextFactory<FlowpilotDbContext>
{
    public FlowpilotDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<FlowpilotDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new FlowpilotDbContext(optionsBuilder.Options);
    }
}