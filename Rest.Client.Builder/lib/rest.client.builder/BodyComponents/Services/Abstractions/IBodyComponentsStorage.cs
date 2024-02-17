using rest.client.builder.BodyComponents.Models;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.Services.Abstractions;

internal interface IBodyComponentsStorage
{
    void Load(OpenApiDocument openApiDocument);
    BodyComponent GetByName(string name);
}