using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.Builders.Abstractions;

namespace rest.client.builder.Builders.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddBuilders(this IServiceCollection services)
        => services.AddScoped<IRestClientFileBuilder, RestClientFileBuilder>();
}