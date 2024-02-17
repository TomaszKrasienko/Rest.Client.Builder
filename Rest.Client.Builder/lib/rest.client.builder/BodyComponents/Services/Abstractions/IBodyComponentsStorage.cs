using rest.client.builder.BodyComponents.Models;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.Services.Abstractions;

internal interface IBodyComponentsStorage
{
    void Load(OpenApiDoc openApiDoc);
    BodyComponent GetByName(string name);
}