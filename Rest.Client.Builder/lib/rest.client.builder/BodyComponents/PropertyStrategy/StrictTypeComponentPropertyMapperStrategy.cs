using rest.client.builder.BodyComponents.PropertyStrategy.Abstractions;
using rest.client.builder.BodyComponents.Services;
using rest.client.builder.OpenApi.Models;

namespace rest.client.builder.BodyComponents.PropertyStrategy;

internal sealed class StrictTypeComponentPropertyMapperStrategy : IBodyComponentPropertyMapperStrategy
{
    public bool CanBeApplied(ComponentPropertiesDoc componentPropertiesDoc)
        => !string.IsNullOrWhiteSpace(componentPropertiesDoc.Type)
           && componentPropertiesDoc.Items is null
           && string.IsNullOrWhiteSpace(componentPropertiesDoc.Ref);

    public KeyValuePair<string, object> Get(KeyValuePair<string, ComponentPropertiesDoc> openApiProperty)
        => new KeyValuePair<string, object>(openApiProperty.Key, openApiProperty.Value.Type);

}