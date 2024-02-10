using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.HostedServices;

namespace rest.client.builder.Configuration;

public static class Extensions
{
    public static IServiceCollection AddRestClientBuilder(this IServiceCollection services)
        => services
            .AddHostedServices();

    private static IServiceCollection AddHostedServices(this IServiceCollection services)
        => services
            .AddHostedService<ExecutionService>();
}