using rest.client.builder.BodyComponents.Models;

namespace rest.client.builder.File.Builders.Abstractions;

internal interface IBodyComponentFileBuilder
{
    string Build(BodyComponent bodyComponent);
}