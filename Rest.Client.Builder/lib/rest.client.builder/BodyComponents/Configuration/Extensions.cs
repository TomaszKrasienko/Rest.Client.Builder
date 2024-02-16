using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.BodyComponents.PropertyStrategy;
using rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;
using rest.client.builder.BodyComponents.Services;
using rest.client.builder.BodyComponents.Services.Abstractions;

namespace rest.client.builder.BodyComponents.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddBodyComponentsConfiguration(this IServiceCollection services)
        => services
            .AddPropertyStrategy()
            .AddServices();

    private static IServiceCollection AddPropertyStrategy(this IServiceCollection services)
        => services
            .AddSingleton<IBodyComponentPropertyMapperStrategy, StrictTypeComponentPropertyMapperStrategy>();

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddSingleton<IBodyComponentsStorage, BodyComponentsStorage>();
}