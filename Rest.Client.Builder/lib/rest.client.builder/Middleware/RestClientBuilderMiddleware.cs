using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Middleware;

internal sealed class RestClientBuilderMiddleware : IMiddleware
{
    private readonly IServiceProvider _serviceProvider;
    private bool _isExecuted = false;
    public RestClientBuilderMiddleware(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!_isExecuted)
        {
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IRestClientFileService>();
            await service.Execute();
            _isExecuted = true;
        }
        await next(context);
    }
}