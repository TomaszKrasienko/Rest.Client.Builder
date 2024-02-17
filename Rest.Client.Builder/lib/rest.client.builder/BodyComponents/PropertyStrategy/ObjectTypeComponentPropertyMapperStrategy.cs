using rest.client.builder.BodyComponents.Models;
using rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.PropertyStrategy;

internal sealed class ObjectTypeComponentPropertyMapperStrategy : IBodyComponentPropertyMapperStrategy
{
    public bool CanBeApplied(ComponentPropertiesOpenApiDocument componentPropertiesDoc)
        => string.IsNullOrWhiteSpace(componentPropertiesDoc.Type)
           && componentPropertiesDoc.Items is null
           && !string.IsNullOrWhiteSpace(componentPropertiesDoc.Reference);

    public KeyValuePair<string, BodyComponentProperty> Get(KeyValuePair<string, ComponentPropertiesOpenApiDocument> openApiProperty)
        => new KeyValuePair<string, BodyComponentProperty>(openApiProperty.Key, new BodyComponentProperty()
        {
            Reference = openApiProperty.Value.Reference
        });
}