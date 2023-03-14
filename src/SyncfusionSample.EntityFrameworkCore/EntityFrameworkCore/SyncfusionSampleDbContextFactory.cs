using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SyncfusionSample.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SyncfusionSampleDbContextFactory : IDesignTimeDbContextFactory<SyncfusionSampleDbContext>
{
    public SyncfusionSampleDbContext CreateDbContext(string[] args)
    {
        SyncfusionSampleEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SyncfusionSampleDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SyncfusionSampleDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SyncfusionSample.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
