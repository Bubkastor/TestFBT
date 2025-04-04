using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Persistance;

public static class ValidateExtensions
{
    public static OptionsBuilder<TOptions> ValidateDataAnnotationsRecursively<TOptions>(this OptionsBuilder<TOptions> builder, string? rootPath = null) where TOptions : class
    {
        builder.Services.AddSingleton<IValidateOptions<TOptions>>(new RecursiveDataAnnotationValidateOptions<TOptions>(builder.Name, rootPath: rootPath));
        return builder;
    }

    public static OptionsBuilder<TOptions> BindAndValidateDataAnnotationsOnStartRecursively<TOptions>(this OptionsBuilder<TOptions> optionsBuilder, IConfiguration configuration) where TOptions : class
    {
        return optionsBuilder.Bind(configuration)
            .ValidateDataAnnotationsRecursively((configuration as IConfigurationSection)?.Path)
            .ValidateOnStart();
    }
}
