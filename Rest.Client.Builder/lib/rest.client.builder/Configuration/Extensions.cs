using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using rest.client.builder.BodyComponents.Configuration;
using rest.client.builder.File.Builders.Configuration;
using rest.client.builder.File.Configuration;
using rest.client.builder.Middleware;
using rest.client.builder.OpenApi.Communication.Configuration;
using rest.client.builder.Services;
using rest.client.builder.Services.Abstractions;

namespace rest.client.builder.Configuration;

public static class Extensions
{
    public static IServiceCollection AddRestClientBuilder(this IServiceCollection services)
        => services
            .AddOpenApiConfiguration("http://localhost:5226", 3, new TimeSpan(00,00,15),
                "swagger/v1/swagger.json")
            .AddFileWriting()
            .AddBuilders()
            .AddBodyComponentsConfiguration()
            .AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IRestClientFileService, RestClientFileService>()
            .AddSingleton<RestClientBuilderMiddleware>();

    public static WebApplication UseRestClientBuilder(this WebApplication app)
    {
        app.UseMiddleware<RestClientBuilderMiddleware>();
        return app;
    }

}