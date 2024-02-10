using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.HostedServices;
using rest.client.builder.Searchers;
using rest.client.builder.Searchers.Abstractions;
using rest.client.builder.Services;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Configuration;

public static class Extensions
{
    public static IServiceCollection AddRestClientBuilder(this IServiceCollection services)
        => services
            .AddHostedServices()
            .AddSearchers()
            .AddServices();

    private static IServiceCollection AddHostedServices(this IServiceCollection services)
        => services
            .AddHostedService<ExecutionService>();

    private static IServiceCollection AddSearchers(this IServiceCollection services)
        => services
            .AddSingleton<IAssembliesSearcher, AssembliesSearcher>()
            .AddSingleton<IControllerSearcher, ControllersSearcher>();

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddSingleton<IRestClientFileService, RestClientFileService>();
}