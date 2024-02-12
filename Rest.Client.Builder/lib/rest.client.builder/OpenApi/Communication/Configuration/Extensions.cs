using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using rest.client.builder.Configuration;
using rest.client.builder.OpenApi.Communication.Clients;
using rest.client.builder.OpenApi.Communication.Clients.Abstractions;

namespace rest.client.builder.OpenApi.Communication.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services,
        string appAddress, int? retries = null, TimeSpan? timeOut = null, string openApiPath = null)
        => services
            .AddHttpClient(appAddress, retries, timeOut)
            .AddServices(openApiPath);
    private static IServiceCollection AddServices(this IServiceCollection services, string openApiPath = null)
    {
        var path = openApiPath ?? ConfigurationConst.OpenApiDefaultPath;
        services.AddScoped<IOpenApiClient>(sp =>
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var logger = sp.GetRequiredService<ILogger<OpenApiClient>>();
            return new OpenApiClient(logger, httpClientFactory.CreateClient(ConfigurationConst.OpenApiClientKey), path);
        });
        return services;
    }

    private static IServiceCollection AddHttpClient(this IServiceCollection services,
        string appAddress, int? retries = null, TimeSpan? timeOut = null)
    {
        if (string.IsNullOrWhiteSpace(appAddress))
        {
            throw new ArgumentException("App address can not be null or empty");
        }
        var openApiRetries = retries ?? ConfigurationConst.OpenApiRetries;
        var openApiTimeOut = timeOut ?? TimeSpan.Parse(ConfigurationConst.OpenApiTimeOut);
        
        var retryPolicy = Policy.HandleResult<HttpResponseMessage>(res
                => !res.IsSuccessStatusCode)
            .RetryAsync(openApiRetries);
        services.AddHttpClient(ConfigurationConst.OpenApiClientKey, client =>
        {
            client.Timeout = openApiTimeOut;
            client.BaseAddress = new Uri(appAddress);
        }).AddPolicyHandler(retryPolicy);
        return services;
    }
}