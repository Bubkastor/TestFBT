using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace PersistanceMigrations;

public static class PawnDbMigrationsExtensions
{

    public static IHost UpdatePawnDb(this IHost host, IConfiguration pawnDbStorageConfiguration)
    {
        var connectionString = pawnDbStorageConfiguration.GetValue<string>("Database:ConnectionString");
        if (connectionString == null)
            throw new ArgumentException($"Настройка {(pawnDbStorageConfiguration is IConfigurationSection section ? $"{section.Path}:" : "")}ConnectionString не определена.");

        using var serviceProvider = CreateServices(connectionString);

        using var scope = serviceProvider.CreateScope();

        var migrationRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        migrationRunner.MigrateUp();

        return host;
    }
    private static ServiceProvider CreateServices(string connectionString)
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(b => b
                .AddSQLite()
                .WithGlobalConnectionString(connectionString)
                .WithMigrationsIn(false, Assembly.GetExecutingAssembly())
            )
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    private static IMigrationRunnerBuilder WithMigrationsIn(this IMigrationRunnerBuilder builder, bool scanOnlyExportedTypes, params Assembly[] assemblies)
    {
        builder.Services.AddSingleton<IMigrationSourceItem>(new AssemblyMigrationSourceItem(assemblies) { ScanOnlyExportedTypes = scanOnlyExportedTypes });
        return builder;
    }
}
