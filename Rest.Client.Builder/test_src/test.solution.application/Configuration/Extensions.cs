using Microsoft.Extensions.DependencyInjection;
using test.solution.application.Service;

namespace test.solution.application.Configuration;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddSingleton<ITasksService, TasksService>()
            .AddMediatr();

    private static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        return services;
    }
}