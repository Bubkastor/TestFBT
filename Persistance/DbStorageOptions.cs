using LinqToDB;
using Microsoft.Extensions.Options;

namespace Persistance;

internal class DbStorageOptions
{
    public DataOptions DataOptions { get; init; }

    public DbStorageOptions(IOptions<DbStorageSettings> settingsOpts)
    {
        var settings = settingsOpts.Value;
        var dataOptions = new DataOptions();

        if (settings.IsUseSqlLite)
        {
            dataOptions = dataOptions.UseSQLite(settings.ConnectionString);
        }
        else
        {
            dataOptions = dataOptions.UseSqlServer(settings.ConnectionString);
        }
        dataOptions = dataOptions.UseTraceLevel(System.Diagnostics.TraceLevel.Verbose);
        this.DataOptions = dataOptions;
    }
}
