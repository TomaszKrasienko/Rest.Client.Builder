using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.OpenApi.Communication.Clients.Abstractions;

internal interface IOpenApiClient
{
    Task<OpenApiDoc> GetOpenApiDocumentation();
}