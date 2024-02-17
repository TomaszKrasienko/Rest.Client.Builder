using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.File.Abstractions;
using rest.client.builder.File.Builders;
using rest.client.builder.File.Builders.Abstractions;

namespace rest.client.builder.File.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddFileWriting(this IServiceCollection services)
        => services
            .AddSingleton<IFileWriter, RestFileWriter>()
            .AddSingleton<IBodyComponentFileBuilder, BodyComponentFileBuilder>();
}