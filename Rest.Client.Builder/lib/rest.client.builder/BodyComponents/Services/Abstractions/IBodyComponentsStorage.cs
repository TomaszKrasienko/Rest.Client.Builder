using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.Services.Abstractions;

public interface IBodyComponentsStorage
{
    void Load(OpenApiDoc openApiDoc);
}