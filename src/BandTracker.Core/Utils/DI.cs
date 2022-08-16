using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BandTracker.Core.Utils;

/// <summary>
/// Dependency injection service container accessor, to be used in places where constructor injection is unavailable
/// </summary>
public static class DI
{
    private static IServiceProvider? _serviceProvider;

    public static void SetProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Resolve something from DI
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static T Resolve<T>() where T : notnull
    {
        EnsureProviderInitialized(_serviceProvider);
        return _serviceProvider.GetRequiredService<T>();
    }

    private static void EnsureProviderInitialized([NotNull] IServiceProvider? serviceProvider)
    {
        if (serviceProvider is null)
        {
            throw new InvalidOperationException("Service provider hasn't been initialized yet. Please call the SetProvider method prior to using this");
        }
    }
}
