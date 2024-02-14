using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.FileWriting.Abstractions;

namespace rest.client.builder.FileWriting.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddFileWriting(this IServiceCollection services)
        => services.AddSingleton<IFileWriter, RestFileWriter>();
}