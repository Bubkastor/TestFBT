using LinqToDB.Common.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance;

public static class DbStorageExtensions
{
    public static IServiceCollection ConfigureDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<DbStorageSettings>().BindAndValidateDataAnnotationsOnStartRecursively(configuration);

        services.TryAddSingleton<DbStorageOptions>();
        services.TryAddScoped<DbStorage>();

        services.AddScoped<IDataRepository, DataRepository>();

        return services;
    }
}
