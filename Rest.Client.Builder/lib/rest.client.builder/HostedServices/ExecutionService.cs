using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.HostedServices;

internal sealed class ExecutionService : IHostedService
{
    private readonly ILogger<ExecutionService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public ExecutionService(ILogger<ExecutionService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Builder rest client file");
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IRestClientFileService>();
        await handler.Execute();
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}